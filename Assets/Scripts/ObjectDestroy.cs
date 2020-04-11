using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WaitObjectGone());
    }

    IEnumerator WaitObjectGone()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
