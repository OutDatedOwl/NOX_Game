using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private GameObject deathRayParticles;
    [SerializeField] private Transform hands;
    [SerializeField] private UI_Manager UI;
    [SerializeField] private ItemSlot[] itemSlot_ActionBar;
    GameObject[] actionBarSpell;
    Animator anim;
    CharacterController player;
    Camera cam;
    Quaternion lookDirection;
    Ray ray;
    RaycastHit hit;
    Vector3 direction, targetDirection, newDirection, shootDirection;
    float singleStep;
    public float speed;
    [HideInInspector] public bool dead;

    private void Start()
    {
        player = GetComponent<CharacterController>();
        cam = Camera.main;
        anim = GetComponent<Animator>();
        for (int i = 0; i < itemSlot_ActionBar.Length; i++)
        {
            if (itemSlot_ActionBar[i] != null)
                return;
            else
                itemSlot_ActionBar[i] = actionBarSpell[i].GetComponent<ItemSlot>();
        }
    }

    void MoveToPoint(Vector3 point)
    {
        if ((point - transform.position).magnitude < 0.1f) return;

        direction = new Vector3((hit.point.x - transform.position.x) * speed * Time.deltaTime, 0, (hit.point.z - transform.position.z) * speed * Time.deltaTime);
        direction = Vector3.ClampMagnitude(direction, 1);

        PlayerRotation();

        if(player.enabled)
            player.Move(direction);
    }

    /* UN 0 North
    * IN 1 NorthEast
    * CHA 2 East
    * DO 3 SouthEast
    * ZO 4 South
    * RO 5 SouthWest
    * ET 6 West
    * KA 7 NorthWest
    */
    #region
    void Cast_Spell_1()
    {// SpellChantSequence, Name Of Spell, Direction, ManaCost, Damage
        UI.Parse_Spell_Sequence(itemSlot_ActionBar[0].Spell_Return(), shootDirection, hit.point, hit.transform); 
    }

    void Cast_Spell_2()
    {
        UI.Parse_Spell_Sequence(itemSlot_ActionBar[1].Spell_Return(), shootDirection, hit.point, hit.transform);
    }

    void Cast_Spell_3()
    {
        UI.Parse_Spell_Sequence(itemSlot_ActionBar[2].Spell_Return(), shootDirection, hit.point, hit.transform);
    }

    void Cast_Spell_4()
    {
        UI.Parse_Spell_Sequence(itemSlot_ActionBar[3].Spell_Return(), shootDirection, hit.point, hit.transform);
    }

    void Cast_Spell_5()
    {
        UI.Parse_Spell_Sequence(itemSlot_ActionBar[4].Spell_Return(), shootDirection, hit.point, hit.transform);
    }
    #endregion
    private void MouseInputs()
    {
        shootDirection = new Vector3(hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z);
        if (Input.GetMouseButton(1))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                MoveToPoint(hit.point);
            }
            anim.SetBool("RUN", true);
        }
    }

    private void PlayerRotation()
    {
        // The step size is equal to speed times frame time.
        singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
        if(player.enabled && !dead)
            transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void AnimationEnded()
    {
        anim.SetBool("Falcon_Punch", false);
    }

    private void ActionBarInputs()
    {
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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Cast_Spell_4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Cast_Spell_5();
        }
    }

    private void Update()
    {
        MouseInputs();
        ActionBarInputs();
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
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 60f);
    }
}
