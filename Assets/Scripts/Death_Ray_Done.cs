using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Ray_Done : MonoBehaviour
{
    ParticleSystem particle;

    private void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(Dissolve_Partices());
        }
    }

    IEnumerator Dissolve_Partices()
    {
        yield return new WaitForSeconds(particle.main.duration);
        gameObject.SetActive(false);
    }
}
