using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Particle : MonoBehaviour
{
    private void Update()
    {
        Destroy(this.gameObject, 1.0f);
    }
}
