﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private static Game_Manager _instance = null;
    public static Game_Manager Get()
    {
        if (_instance == null)
            _instance = (Game_Manager)FindObjectOfType(typeof(Game_Manager));
        return _instance;
    }
    public AudioClip[] audioArray;
    // DeathRay 0
    // ManaDrain 1
    // Charge 2
    // StunOn 3
    // StunOff 4
    // SpellDrag 5
    // SpellPull 6
    // NotEnoughMana 7
}
