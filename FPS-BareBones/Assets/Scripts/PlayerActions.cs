using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool isCrouched;
    [SerializeField] private bool isSprinting;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxJumpHeight;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float sprintModifier;


    private Vector3 crouchedVector;
    private Vector3 standingVector;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        maxJumpHeight = 2f;
        jumpForce = 10f;
        isOnGround = true;
        playerRB.AddForce(Vector3.down);
        crouchedVector = Vector3.Scale(playerObject.transform.localScale, new Vector3(1f, .5f, 1f));
        standingVector = Vector3.Scale(playerObject.transform.localScale, new Vector3(1f, 1f, 1f));

    }

    void Update()
    {
        Jump();
        Crouch();
        Sprint();
        QuickAttack();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (transform.position.y > maxJumpHeight)
        {
            playerRB.AddForce(Vector3.down, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
            playerRB.velocity = Vector3.zero;
        }
    }
    private void Crouch()
    {
        //CROUCH TOGGLE
        /*        if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouched == false)
                {
                    playerObject.transform.localScale = crouchedVector;
                    isCrouched = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouched == true)
                {
                    playerObject.transform.localScale = standingVector;
                    isCrouched = false;
                }*/

        if (Input.GetKey(KeyCode.LeftControl) && isCrouched == false)
        {
            playerObject.transform.localScale = crouchedVector;
            isCrouched = true;
        }
        else if (!Input.GetKey(KeyCode.LeftControl) && isCrouched == true)
        {
            playerObject.transform.localScale = standingVector;
            isCrouched = false;
        }
    }
    private void Sprint()
    {
        if (sprintModifier <= 0)
        {
            sprintModifier = 1;
        }
        //SPRINT TOGGLE
        /*        if (Input.GetKeyDown(KeyCode.LeftShift) && isSprinting == false)
                {
                    GetComponent<PlayerMovement>().speed *= sprintModifier;
                    isSprinting = true;
                }
                else if (Input.GetKeyDown(KeyCode.LeftShift) && isSprinting == true)
                {
                    GetComponent<PlayerMovement>().speed /= sprintModifier;
                    isSprinting = false;
                }*/
        if (Input.GetKey(KeyCode.LeftShift) && isSprinting == false)
        {
            GetComponent<PlayerMovement>().Speed *= sprintModifier;
            isSprinting = true;
        }
        else if (!Input.GetKey(KeyCode.LeftControl) && isSprinting == true)
        {
            GetComponent<PlayerMovement>().Speed /= sprintModifier;
            isSprinting = false;
        }
    }
    private void QuickAttack()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            //ToDo - Create Quickattack Event to subscribe to 
        }
    }
    private void MovementAbility()
    {
/*        if (Input.GetKeyDown(KeyCode.V))
        {
            //ToDo - Create MovementAbility Event to subscribe to 
        }*/
    }
    private void HealingAbility()
    {
        /*        if (Input.GetKeyDown(KeyCode.V))
                {
                    //ToDo - Create HealingAbility Event to subscribe to 
                }*/
    }
    private void DefenceAbility()
    {
        /*        if (Input.GetKeyDown(KeyCode.V))
                {
                    //ToDo - Create DefenceAbility Event to subscribe to 
                }*/
    }
    private void OffenceAbility()
    {
        /*        if (Input.GetKeyDown(KeyCode.V))
                {
                    //ToDo - Create OffenceAbility Event to subscribe to 
                }*/
    }
    private void UltimateAbility()
    {
        /*        if (Input.GetKeyDown(KeyCode.V))
                {
                    //ToDo - Create UltimateAbility Event to subscribe to 
                }*/
    }
}

