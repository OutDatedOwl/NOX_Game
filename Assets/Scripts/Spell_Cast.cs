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
    //Vector3 manaDrainDirection;
    //public float speed;
    //float singleStep;
    //ParticleSystem manaDrain_Particles;
    //List<Spell_Methods> spells = new List<Spell_Methods>();
    //Spell_Methods spell = delegate { };

    private void Start()
    {
        hash_Browns.Add("S_DeathRay", S_DeathRay);
        hash_Browns.Add("S_Fireball", S_FireBall);
        hash_Browns.Add("S_DrainMana", S_ManaDrain);
        //spells.Add(S_DeathRay);
        //spells[0]("d");
        //hash_Browns.Add("DeathRay", 0);
        //spell = FindSpell;
    }

    private void Update()
    {
        foreach (Mana_Drain_Particles manaPillar in mana_Pillar_List)
        {
            if (Vector3.Distance(manaPillar.transform.position, transform.position) < 30f)
            {
                mana_Drain_Object = manaPillar;
            }
            else
                return;
        }
    }

    public void FindSpell(string spell_Name, Vector3 spell_Direction)
    {
        if (hash_Browns.ContainsKey(spell_Name))
        {
            hash_Browns[spell_Name](spell_Name, spell_Direction);
        }
        else
            return;
        //hash_Browns.ContainsKey(spell_Name);
        //spell = spell_Name;
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
        //manaDrainDirection = transform.position - manaDrain_Particles.transform.position;
        //manaDrain_Particles.transform.rotation = Quaternion.LookRotation(manaDrainDirection);
        //manaDrain_Particles.Play();
        //manaDrainPillars_Particles.loop;
        //manaDrainPillars.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(manaDrainPillarClosest.transform.position, manaDrainDirection);
    }
}
