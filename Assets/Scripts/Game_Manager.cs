using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioArray;
    public List<AudioSource> audioSourceList;

    public void PlaySound(int spell_Number)
    {
        switch (spell_Number)
        {
            case 0:
                audioSourceList[0].clip = audioArray[0];
                audioSourceList[0].Play();
                break;
        }
    }
}
