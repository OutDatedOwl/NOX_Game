using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Mana : MonoBehaviour
{
    [SerializeField]Image[] Health_Bar, Mana_Bar;
    float Health = 100, Mana = 150, currentHealth, currentMana;//, calculateHealth, calculateMana;
    int valueOfMana = 10;

    private void Start()
    {
        currentHealth = Health;
        currentMana = Mana;
    }

    private void Update()
    {
        for (int i = 0; i < Mana_Bar.Length; i++)
        {
            if (currentMana % 10 == 0)
            {

            }
        }
        //calculateHealth = currentHealth / Health;
        //calculateMana = currentMana / Mana;
        //Health_Bar.fillAmount = Mathf.MoveTowards(Health_Bar.fillAmount, calculateHealth, Time.deltaTime);
        //Mana_Bar.fillAmount = Mathf.MoveTowards(Mana_Bar.fillAmount, calculateMana, Time.deltaTime);
    }

    public void Mana_Cost(float mana_Cost)
    {
        currentMana = currentMana - mana_Cost;
        //Mana_Bar.fillAmount = Mana_Bar.fillAmount - mana_Cost/1000f;
    }

    public void Damage(float damage)
    {
        currentHealth = currentHealth - damage;
    }
}
