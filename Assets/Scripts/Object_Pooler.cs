using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pooler : MonoBehaviour
{
    public static GameObject GetPooledObject(List<GameObject> objectInList)
    {
        for (int i = 0; i < objectInList.Count; i++)
        {
            if (!objectInList[i].activeInHierarchy)
            {
                return objectInList[i];
            }
        }

        return null;
    }
}
