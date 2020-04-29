using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private float gestureTimeElapse = 0.05f;
    [SerializeField] private Image[] direction_Gestures;
    [SerializeField] private AudioClip[] audio_Clip;
    [SerializeField] private Spell_Cast spell_Cast;
    string[] spell_Chant_Sequence, spell_ID_spell_Gesture_Split;
    int[] gestureSequenceArray;
    int counter = 0;
    AudioSource audio_Source;
    string spell_ID;
    Transform target_Name;
    float manaCost, damageDealt;
    Vector3 spell_Direction, mouseLocation;

    private void Start()
    {
        audio_Source = GetComponent<AudioSource>();
    }
    // Take NumericalSpellChantSequence i.e. "0,1,1", Spell Name, Direction Of Caster Is Facing
    public void Parse_Spell_Sequence(string spell_ID_spell_Gestures, Vector3 spell_Direction_Import, Vector3 mouseLocation_Import, Transform target_Name_Import)
    {
        try // Try to parse string from Spell in actionbar
        {
            spell_ID_spell_Gesture_Split = spell_ID_spell_Gestures.Split('/'); // Split spellName first then spellChantSequence second
            spell_ID = spell_ID_spell_Gesture_Split[0];
            spell_Chant_Sequence = spell_ID_spell_Gesture_Split[1].Split(','); // Split NumSpellChant into individual chars
            gestureSequenceArray = new int[spell_Chant_Sequence.Length];
            for (int i = 0; i < spell_Chant_Sequence.Length; i++)
            {
                gestureSequenceArray[i] = int.Parse(spell_Chant_Sequence[i]);
            }
            // Coroutines can't take more than one parameter so we must store variables in another method
            PassValues(spell_ID, spell_Direction_Import, mouseLocation_Import, spell_ID_spell_Gesture_Split[2], spell_ID_spell_Gesture_Split[3], target_Name_Import);
            StartCoroutine(MagicGestures(gestureSequenceArray[0]));
        }
        catch (Exception no_Spell)
        {
            print("ERROR NO SPELL INFO");
            return;
        }
    }

    IEnumerator MagicGestures(int gestureSequence) // Play Sound, Image of that char
    {
        /* UN 0 North
         * IN 1 NorthEast
         * CHA 2 East
         * DO 3 SouthEast
         * ZO 4 South
         * RO 5 SouthWest
         * ET 6 West
         * KA 7 NorthWest
         */
        switch(gestureSequence) 
        {
            case 0:
                direction_Gestures[0].color = new Color(direction_Gestures[0].color.r, direction_Gestures[0].color.g, direction_Gestures[0].color.b, 1);
                audio_Source.clip = audio_Clip[0];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[0].color = new Color(direction_Gestures[0].color.r, direction_Gestures[0].color.g, direction_Gestures[0].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 1:
                direction_Gestures[1].color = new Color(direction_Gestures[1].color.r, direction_Gestures[1].color.g, direction_Gestures[1].color.b, 1);
                audio_Source.clip = audio_Clip[1];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[1].color = new Color(direction_Gestures[1].color.r, direction_Gestures[1].color.g, direction_Gestures[1].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 2:
                direction_Gestures[2].color = new Color(direction_Gestures[2].color.r, direction_Gestures[2].color.g, direction_Gestures[2].color.b, 1);
                audio_Source.clip = audio_Clip[2];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[2].color = new Color(direction_Gestures[2].color.r, direction_Gestures[2].color.g, direction_Gestures[2].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 3:
                direction_Gestures[3].color = new Color(direction_Gestures[3].color.r, direction_Gestures[3].color.g, direction_Gestures[3].color.b, 1);
                audio_Source.clip = audio_Clip[3];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[3].color = new Color(direction_Gestures[3].color.r, direction_Gestures[3].color.g, direction_Gestures[3].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 4:
                direction_Gestures[4].color = new Color(direction_Gestures[4].color.r, direction_Gestures[4].color.g, direction_Gestures[4].color.b, 1);
                audio_Source.clip = audio_Clip[4];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[4].color = new Color(direction_Gestures[4].color.r, direction_Gestures[4].color.g, direction_Gestures[4].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 5:
                direction_Gestures[5].color = new Color(direction_Gestures[5].color.r, direction_Gestures[5].color.g, direction_Gestures[5].color.b, 1);
                audio_Source.clip = audio_Clip[5];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[5].color = new Color(direction_Gestures[5].color.r, direction_Gestures[5].color.g, direction_Gestures[5].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 6:
                direction_Gestures[6].color = new Color(direction_Gestures[6].color.r, direction_Gestures[6].color.g, direction_Gestures[6].color.b, 1);
                audio_Source.clip = audio_Clip[6];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[6].color = new Color(direction_Gestures[6].color.r, direction_Gestures[6].color.g, direction_Gestures[6].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 7:
                direction_Gestures[7].color = new Color(direction_Gestures[7].color.r, direction_Gestures[7].color.g, direction_Gestures[7].color.b, 1);
                audio_Source.clip = audio_Clip[7];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[7].color = new Color(direction_Gestures[7].color.r, direction_Gestures[7].color.g, direction_Gestures[7].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < gestureSequenceArray.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(gestureSequenceArray[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                    counter = 0;
                    break;
                }
                break;
            case 100:
                spell_Cast.FindSpell(spell_ID, spell_Direction, mouseLocation, manaCost, damageDealt, target_Name);
                break;
            case 101:
                Debug.Log("WARCRY");
                break;
        }
    }

    void PassValues(string spell_ID, Vector3 spell_Direction_Import, Vector3 mouseLocation_Import,
        string manaCost_Import, string damageDealt_Import, Transform target_Name_Import)
    {
        if (spell_ID == null)
            spell_ID = " ";
        spell_Direction = spell_Direction_Import;
        manaCost = float.Parse(manaCost_Import);
        damageDealt = float.Parse(damageDealt_Import);
        target_Name = target_Name_Import;
        mouseLocation = new Vector3(mouseLocation_Import.x, mouseLocation_Import.y + 8.1f, mouseLocation_Import.z);
    }

}