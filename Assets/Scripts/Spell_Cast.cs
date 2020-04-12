using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Cast : MonoBehaviour
{
    Dictionary<string,Spell_Methods> hash_Browns = new Dictionary<string, Spell_Methods>();
    List<GameObject> teleportToLocParticlesList = new List<GameObject>();
    List<int> usedValues = new List<int>();
    delegate void Spell_Methods(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation);
    [SerializeField] Game_Manager audio_Manager;
    [SerializeField] GameObject particles_DeathRay, particles_FireBall, particles_TeleportToLoc;
    [SerializeField] Transform hands;
    [SerializeField] Transform[] blink_Safe_Spot;
    [SerializeField] List<Mana_Drain_Particles> mana_Pillar_List = new List<Mana_Drain_Particles>();
    [SerializeField] int TotalAmountOfSpellsAllowed = 5;
    Mana_Drain_Particles mana_Drain_Object;
    GameObject deathRay, fireball;

    private void Start()
    {
        hash_Browns.Add("S_DeathRay", S_DeathRay); // Need To Add All Spells In CVS file
        hash_Browns.Add("S_Fireball", S_FireBall);
        hash_Browns.Add("S_DrainMana", S_ManaDrain);
        hash_Browns.Add("S_TeleportToTarget", S_TeleportToTarget);
        hash_Browns.Add("S_Blink", S_Blink);
        for (int i = 0; i < TotalAmountOfSpellsAllowed; i++)
        {
            GameObject teleportObj = (GameObject)Instantiate(particles_TeleportToLoc);
            teleportObj.SetActive(false);
            teleportToLocParticlesList.Add(teleportObj);
        }
    }

    private void Update()
    {
        foreach (Mana_Drain_Particles manaPillar in mana_Pillar_List) // ManaPillarFinder
        {
            if (Vector3.Distance(manaPillar.transform.position, transform.position) < 30f)
            {
                mana_Drain_Object = manaPillar;
            }
            else
                return;
        }
    }

    GameObject GetPooledObject()
    {
        for (int i = 0; i < teleportToLocParticlesList.Count; i++)
        {
            if (!teleportToLocParticlesList[i].activeInHierarchy)
            {
                return teleportToLocParticlesList[i];
            }
        }

        return null;
    }

    // Take In Spell_ID from UI_Manager, Find Method Of That Spell_ID -> Cast That Spell
    public void FindSpell(string spell_Name, Vector3 spell_Direction, Vector3 mouseLocation) 
    {
        if (hash_Browns.ContainsKey(spell_Name))
        {
            hash_Browns[spell_Name](spell_Name, spell_Direction, mouseLocation);
        }
        else
            return;
    }

    private void S_DeathRay(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation)
    {
        audio_Manager.PlaySound(0);
        for (int i = 0; i < 10; i++)
        {
            deathRay = Instantiate(particles_DeathRay, hands.position + Vector3.up, Quaternion.identity);
            deathRay.transform.position = deathRay.transform.position + spell_Direction * i / 10;
        }
    }

    private void S_FireBall(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation)
    {
        fireball = Instantiate(particles_FireBall, hands.position + Vector3.up, Quaternion.LookRotation(transform.forward));
    }

    private void S_ManaDrain(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation)
    {
        if (mana_Drain_Object != null)
        {
            mana_Drain_Object.Drain_Dat_Mana_Son();
        }
    }

    private void S_TeleportToTarget(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation)
    {
        if (particles_TeleportToLoc != null)
        {
            particles_TeleportToLoc = GetPooledObject();
            particles_TeleportToLoc.transform.position = transform.position;
            particles_TeleportToLoc.SetActive(true);
            transform.position = mouseLocation;
        }
    }

    private void S_Blink(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation)
    {
        usedValues.Add(RandomPositions(0, 4));
        particles_TeleportToLoc = GetPooledObject();
        particles_TeleportToLoc.transform.position = transform.position;
        particles_TeleportToLoc.SetActive(true);
        transform.position = blink_Safe_Spot[usedValues[0]].position;
    }

    int RandomPositions(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {
            val = Random.Range(0, 4);
        }
        if (usedValues.Count == 1)
        {
            usedValues.RemoveAt(0);
        }
        return val;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(manaDrainPillarClosest.transform.position, manaDrainDirection);
    }
}
