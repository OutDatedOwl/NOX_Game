using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_Drain_Particles : MonoBehaviour
{
    ParticleSystem manaDrainParticles;
    AudioSource manaDrainSound;
    Collider[] players_Near_Pillar;
    Vector3 manaShootDirection;

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
            manaShootDirection = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(manaShootDirection);
        }
        manaDrainSound.Play();
        manaDrainParticles.Play();
    }
}
