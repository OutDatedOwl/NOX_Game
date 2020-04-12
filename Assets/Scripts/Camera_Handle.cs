using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Handle : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    Vector3 offSet;

    void LateUpdate()
    {
        transform.position = player.position + offSet;
    }
}
