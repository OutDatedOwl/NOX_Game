using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Cast : MonoBehaviour
{
    Dictionary<string,Spell_Methods> hash_Browns = new Dictionary<string, Spell_Methods>();
    delegate void Spell_Methods(string spell_ID, Vector3 spell_Direction);
    [SerializeField] Game_Manager audio_Manager;
    [SerializeField] GameObject deathRayParticles, fireBallParticles;
    [SerializeField] Transform hands;
    [SerializeField] List<Mana_Drain_Particles> mana_Pillar_List = new List<Mana_Drain_Particles>();
    Mana_Drain_Particles mana_Drain_Object;
    GameObject deathRay, fireball;

    private void Start()
    {
        hash_Browns.Add("S_DeathRay", S_DeathRay); // Need To Add All Spells In CVS file
        hash_Browns.Add("S_Fireball", S_FireBall);
        hash_Browns.Add("S_DrainMana", S_ManaDrain);
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

    public void FindSpell(string spell_Name, Vector3 spell_Direction) // Take In Spell_ID from UI_Manager, Find Method Of That Spell_ID -> Cast That Spell
    {
        if (hash_Browns.ContainsKey(spell_Name))
        {
            hash_Browns[spell_Name](spell_Name, spell_Direction);
        }
        else
            return;
    }

    private void S_DeathRay(string spell_ID, Vector3 spell_Direction)
    {
        audio_Manager.PlaySound(0);
        for (int i = 0; i < 10; i++)
        {
            deathRay = Instantiate(deathRayParticles, hands.position + Vector3.up, Quaternion.identity);
            deathRay.transform.position = deathRay.transform.position + spell_Direction * i / 10;
        }
    }

    private void S_FireBall(string spell_ID, Vector3 spell_Direction)
    {
        fireball = Instantiate(fireBallParticles, hands.position + Vector3.up, Quaternion.LookRotation(transform.forward));
    }

    private void S_ManaDrain(string spell_ID, Vector3 spell_Direction)
    {
        if (mana_Drain_Object != null)
        {
            mana_Drain_Object.Drain_Dat_Mana_Son();
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(manaDrainPillarClosest.transform.position, manaDrainDirection);
    }
}
