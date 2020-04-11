﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] GameObject deathRayParticles;
    [SerializeField] Transform hands;
    [SerializeField] UI_Manager UI;
    GameObject deathRay, fireball;
    Animator anim;
    CharacterController player;
    Camera cam;
    Quaternion lookDirection;
    Ray ray;
    RaycastHit hit;
    Vector3 direction, targetDirection, newDirection, shootDirection;
    public float speed;
    float singleStep;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
    }

    void MoveToPoint(Vector3 point)
    {
        if ((point - transform.position).magnitude < 0.1f) return;

        direction = new Vector3((hit.point.x - transform.position.x) * speed * Time.deltaTime, 0, (hit.point.z - transform.position.z) * speed * Time.deltaTime);
        direction = Vector3.ClampMagnitude(direction, 1);

        // The step size is equal to speed times frame time.
        singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        player.Move(direction);
    }
    // Need Actionbar
    void Cast_Spell_1()
    {
        UI.Parse_Spell_Sequence("3,3", "S_DeathRay", shootDirection); // SpellChantSequence, Name Of Spell, Direction
    }

    void Cast_Spell_2()
    {
        UI.Parse_Spell_Sequence("4,4,0", "S_Fireball", shootDirection);
    }

    void Cast_Spell_3()
    {
        UI.Parse_Spell_Sequence("0,7,4,2", "S_DrainMana", shootDirection);
    }

    void Cast_Spell_4()
    {

    }

    void Cast_Spell_5()
    {

    }

    private void Update()
    {
        shootDirection = new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z);
        if (Input.GetMouseButton(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                MoveToPoint(hit.point);
            }
            anim.SetBool("RUN", true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cast_Spell_1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Cast_Spell_2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Cast_Spell_3();
        }
    }

    private void FixedUpdate()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (!Input.GetMouseButton(0))
            {
                targetDirection = new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z);

                singleStep = speed * Time.deltaTime;

                newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
                anim.SetBool("RUN", false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, hit.point);
    }
}
