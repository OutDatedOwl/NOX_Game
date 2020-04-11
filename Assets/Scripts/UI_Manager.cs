using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] float gestureTimeElapse = 0.05f;
    [SerializeField] Image[] direction_Gestures;
    [SerializeField] AudioClip[] audio_Clip;
    [SerializeField] Spell_Cast spell_Cast;
    string[] spell_Chant_Sequence;
    int[] testing;
    int counter = 0;
    AudioSource audio_Source;
    string spell_ID;
    Vector3 spell_Direction;

    private void Start()
    {
        audio_Source = GetComponent<AudioSource>();
    }

    public void Parse_Spell_Sequence(string gestureSequence, string spell_ID_Import, Vector3 spell_Direction_Import)
    {
        spell_Chant_Sequence = gestureSequence.Split(',');
        testing = new int[spell_Chant_Sequence.Length];
        for (int i = 0; i < spell_Chant_Sequence.Length; i++)
        {
            testing[i] = int.Parse(spell_Chant_Sequence[i]);
        }
        spell_ID = spell_ID_Import;
        spell_Direction = spell_Direction_Import;
        StartCoroutine(MagicGestures(testing[0]));
    }

    IEnumerator MagicGestures(int gestureSequence)
    {
        switch(gestureSequence) 
        {
            case 0:
                direction_Gestures[0].color = new Color(direction_Gestures[0].color.r, direction_Gestures[0].color.g, direction_Gestures[0].color.b, 1);
                audio_Source.clip = audio_Clip[0];
                audio_Source.Play();
                yield return new WaitForSeconds(gestureTimeElapse);
                direction_Gestures[0].color = new Color(direction_Gestures[0].color.r, direction_Gestures[0].color.g, direction_Gestures[0].color.b, 0);
                yield return new WaitForSeconds(gestureTimeElapse);
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
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
                if (counter < testing.Length - 1)
                {
                    counter++;
                    StartCoroutine(MagicGestures(testing[counter]));
                }
                else
                {
                    spell_Cast.FindSpell(spell_ID, spell_Direction);
                    counter = 0;
                    break;
                }
                break;
        }
    }
}
