using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistOfVengeance : MonoBehaviour
{
    Vector3 startPoint, endPoint;
    HP_Mana kill_You_Dead;
    [SerializeField] private float speed;
    RaycastHit hit;
    LayerMask floor;
    float moveTime;
    bool slamDunk;

    void Update()
    {
        if (slamDunk)
        {
            moveTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPoint, endPoint, moveTime * speed);
            if (transform.position == endPoint)
            {
                slamDunk = false;
                moveTime = 0;
            }
        }
        else
        {
            moveTime += Time.deltaTime;
            transform.position = Vector3.Lerp(endPoint, startPoint, moveTime * speed);
            if (transform.position == startPoint)
            {
                slamDunk = true;
                moveTime = 0;
                gameObject.SetActive(false);
            }
        }
    }

    public void Get_Fisted(Vector3 where_To_Cast)
    {
        transform.position = where_To_Cast + Vector3.up * 50f;
        startPoint = transform.position;
        endPoint = new Vector3(where_To_Cast.x, where_To_Cast.y - 8.1f, where_To_Cast.z);
        gameObject.SetActive(true);
        slamDunk = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * 20);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            kill_You_Dead = other.GetComponent<HP_Mana>();
            kill_You_Dead.Damage(100f);
        }
    }
}
