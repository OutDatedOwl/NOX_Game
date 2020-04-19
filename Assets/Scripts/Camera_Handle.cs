using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Handle : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offSet;

    void LateUpdate()
    {
        transform.position = player.position + offSet;
    }
}
