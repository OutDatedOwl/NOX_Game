using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject fireball;
    GameObject fireBlast;
    Rigidbody rb;
    SphereCollider col;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        fireBlast = Instantiate(fireball, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
