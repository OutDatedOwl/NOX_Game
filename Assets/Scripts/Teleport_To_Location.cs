using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_To_Location : MonoBehaviour
{
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(PlayTeleportSound());
        }
    }

    IEnumerator PlayTeleportSound()
    {
        yield return new WaitForSeconds(source.clip.length);
        this.gameObject.SetActive(false);
    }
}
