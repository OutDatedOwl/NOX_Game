using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Cast : MonoBehaviour
{
    Dictionary<string,Spell_Methods> hash_Browns = new Dictionary<string, Spell_Methods>();
    List<GameObject> teleportToLocParticlesList = new List<GameObject>();
    List<GameObject> teleportSmokeParticlesList = new List<GameObject>();
    List<GameObject> particles_DeathRayList = new List<GameObject>();
    List<int> usedValues = new List<int>();
    delegate void Spell_Methods(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt);
    [SerializeField] GameObject particles_DeathRay, particles_FireBall, particles_TeleportToLoc, particle_TeleportSmoke, particles_FistOfVengeance;
    [SerializeField] Transform hands;
    [SerializeField] Transform[] blink_Safe_Spot;
    [SerializeField] List<Mana_Drain_Particles> mana_Pillar_List = new List<Mana_Drain_Particles>();
    [SerializeField] int TotalAmountOfSpellsAllowed = 5;
    AudioSource audioSource;
    Mana_Drain_Particles mana_Drain_Object;
    HP_Mana hp_Mana_System;
    FistOfVengeance fistOfVengeanceScript;
    GameObject fireball;

    private void Start()
    {
        hp_Mana_System = GetComponent<HP_Mana>();
        hash_Browns.Add("S_DeathRay", S_DeathRay); // Need To Add All Spells In CVS file
        hash_Browns.Add("S_Fireball", S_FireBall);
        hash_Browns.Add("S_DrainMana", S_ManaDrain);
        hash_Browns.Add("S_TeleportToTarget", S_TeleportToTarget);
        hash_Browns.Add("S_Blink", S_Blink);
        hash_Browns.Add("S_FistOfVengeance", S_FistOfVengeance);
        audioSource = GetComponent<AudioSource>();
        GameObject fistOfVengenaceObj = (GameObject)Instantiate(particles_FistOfVengeance);
        fistOfVengeanceScript = fistOfVengenaceObj.GetComponent<FistOfVengeance>();
        fistOfVengenaceObj.SetActive(false);

        for (int i = 0; i < TotalAmountOfSpellsAllowed; i++)
        {
            GameObject telepotToLocObj = (GameObject)Instantiate(particles_TeleportToLoc);
            GameObject teleportSmokeObj = (GameObject)Instantiate(particle_TeleportSmoke);

            telepotToLocObj.SetActive(false);
            teleportSmokeObj.SetActive(false);

            teleportToLocParticlesList.Add(telepotToLocObj);
            teleportSmokeParticlesList.Add(teleportSmokeObj);

            if (i == TotalAmountOfSpellsAllowed - 1)
            {
                for (int j = 0; j < TotalAmountOfSpellsAllowed + 5; j++)
                {
                    GameObject particles_DeathRayObj = (GameObject)Instantiate(particles_DeathRay);
                    particles_DeathRayObj.SetActive(false);
                    particles_DeathRayList.Add(particles_DeathRayObj);
                }
            }
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

    GameObject GetPooledObject(List<GameObject> object_Pool_List)
    { 
        return Object_Pooler.GetPooledObject(object_Pool_List);
    }

    // Take In Spell_ID from UI_Manager, Find Method Of That Spell_ID -> Cast That Spell
    public void FindSpell(string spell_Name, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt) 
    {
        if (hash_Browns.ContainsKey(spell_Name))
        {
            hash_Browns[spell_Name](spell_Name, spell_Direction, mouseLocation, manaCost, damageDealt);
        }
        else
            return;
    }

    private void S_DeathRay(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt)
    {
        if (hp_Mana_System.Mana_Cost(manaCost))
        {
            audioSource.clip = Game_Manager.Get().audioArray[0];
            audioSource.Play();
            for (int i = 0; i < 10; i++)
            {
                particles_DeathRay = GetPooledObject(particles_DeathRayList);
                particles_DeathRayList[i].transform.position = hands.transform.position + spell_Direction * i / 10;
                particles_DeathRayList[i].SetActive(true);
            }
        }
        else
            print("NOT ENOUGH MANA");
    }

    private void S_FireBall(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt)
    {
        if (hp_Mana_System.Mana_Cost(manaCost))
        {
            fireball = Instantiate(particles_FireBall, hands.position + Vector3.up, Quaternion.LookRotation(transform.forward));
        }
        else
            print("NOT ENOUGH MANA");
    }

    private void S_ManaDrain(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt)
    {
        if (mana_Drain_Object != null)
        {
            mana_Drain_Object.Drain_Dat_Mana_Son();
        }
    }

    private void S_TeleportToTarget(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt)
    {
        if (particles_TeleportToLoc != null)
        {
            if (hp_Mana_System.Mana_Cost(manaCost))
            {
                particles_TeleportToLoc = GetPooledObject(teleportToLocParticlesList);
                particle_TeleportSmoke = GetPooledObject(teleportSmokeParticlesList);
                particles_TeleportToLoc.transform.position = transform.position;
                particle_TeleportSmoke.transform.position = mouseLocation;
                particles_TeleportToLoc.SetActive(true);
                particle_TeleportSmoke.SetActive(true);
                transform.position = mouseLocation;
            }
            else
                print("NOT ENOUGH MANA");
        }
    }

    private void S_Blink(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt)
    {
        if (hp_Mana_System.Mana_Cost(manaCost))
        {
            usedValues.Add(RandomPositions(0, 4));
            particles_TeleportToLoc = GetPooledObject(teleportToLocParticlesList);
            particle_TeleportSmoke = GetPooledObject(teleportSmokeParticlesList);
            particles_TeleportToLoc.transform.position = transform.position;
            particle_TeleportSmoke.transform.position = blink_Safe_Spot[usedValues[0]].position;
            particles_TeleportToLoc.SetActive(true);
            particle_TeleportSmoke.SetActive(true);
            transform.position = blink_Safe_Spot[usedValues[0]].position;
        }
        else
            print("NOT ENOUGH MANA");
    }

    private void S_FistOfVengeance(string spell_ID, Vector3 spell_Direction, Vector3 mouseLocation, float manaCost, float damageDealt)
    {
        if (hp_Mana_System.Mana_Cost(manaCost))
        {
            fistOfVengeanceScript.Get_Fisted(mouseLocation);
        }
        else
            print("NOT ENOUGH MANA");
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
}
