using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Mana : MonoBehaviour
{
    [SerializeField]Image Health_Bar, Mana_Bar;
    [SerializeField] AudioSource audioSource_HP_MANA;
    Animator anim;
    Player_Movement player;
    float Health = 100, Mana = 150, currentHealth, currentMana, calculateHealth, calculateMana;
    bool heDead;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = Health;
        currentMana = Mana;
        player = GetComponent<Player_Movement>();
    }

    private void Update()
    {
        calculateHealth = currentHealth / Health;
        calculateMana = currentMana / Mana;
        Health_Bar.fillAmount = Mathf.MoveTowards(Health_Bar.fillAmount, calculateHealth, Time.deltaTime);
        Mana_Bar.fillAmount = Mathf.MoveTowards(Mana_Bar.fillAmount, calculateMana, Time.deltaTime);

        if (currentHealth == 0 && !heDead)
            Death();
    }

    public bool Mana_Cost(float mana_Cost)
    {
        if (currentMana - mana_Cost < 0)
        {
            return false;
        }
        else
        {
            currentMana = currentMana - mana_Cost;
            return true;
        }
            
    }

    public void Blue_Koolaid()
    {
        currentMana += 40;
        if (currentMana > 150)
        {
            currentMana = 150;
        }
    }

    public void Damage(float damage)
    {
        currentHealth = currentHealth - damage;
    }

    private void Death()
    {
        heDead = true;
        anim.SetBool("Dead", true);
        player.dead = true;
        player.enabled = false;
        audioSource_HP_MANA.Play();
    }
}
