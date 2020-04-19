using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Mana : MonoBehaviour
{
    [SerializeField]Image Health_Bar, Mana_Bar;
    float Health = 100, Mana = 150, currentHealth, currentMana, calculateHealth, calculateMana;

    private void Start()
    {
        currentHealth = Health;
        currentMana = Mana;
    }

    private void Update()
    {
        calculateHealth = currentHealth / Health;
        calculateMana = currentMana / Mana;
        Health_Bar.fillAmount = Mathf.MoveTowards(Health_Bar.fillAmount, calculateHealth, Time.deltaTime);
        Mana_Bar.fillAmount = Mathf.MoveTowards(Mana_Bar.fillAmount, calculateMana, Time.deltaTime);
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
}
