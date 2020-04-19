using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_Drain_Particles : MonoBehaviour
{
    ParticleSystem manaDrainParticles;
    AudioSource manaDrainSound;
    Collider[] players_Near_Pillar;
    Vector3 manaShootDirection;
    HP_Mana give_Me_Blue_Koolaid;

    private void Start()
    {
        manaDrainParticles = transform.GetComponent<ParticleSystem>();
        manaDrainSound = transform.GetComponent<AudioSource>();
    }

    public void Drain_Dat_Mana_Son()
    {
        players_Near_Pillar = Physics.OverlapSphere(transform.position, 30f);
        foreach (var player in players_Near_Pillar)
        {
            if (player.gameObject.tag == "Player")
            {
                manaShootDirection = player.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(manaShootDirection);
                give_Me_Blue_Koolaid = player.gameObject.GetComponent<HP_Mana>();
                give_Me_Blue_Koolaid.Blue_Koolaid();
                manaDrainSound.Play();
                manaDrainParticles.Play();
            }
        }
    }
}
