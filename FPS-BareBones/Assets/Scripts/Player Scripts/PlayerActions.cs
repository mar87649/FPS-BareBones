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


    private InputAsset controls;
    private Vector3 crouchedVector;
    private Vector3 standingVector;
    private float sprintSpeed;
    private float walkSpeed;

    private void Awake()
    {
        controls = new InputAsset();
        //controls.Player.Attack1.performed += e =>  
        controls.Player.Jump.performed += e => Jump();
        controls.Player.Crouch.performed += e => Crouch();
        controls.Player.Crouch.canceled += e => Stand();
        controls.Player.Sprint.performed += e => Sprint();
        controls.Player.Sprint.canceled += e => Walk();
        controls.Player.QuickAttack.performed += e => QuickAttack();
        controls.Player.MovementAbility.performed += e => MovementAbility();
        controls.Player.OffenceAbility.performed += e => OffenceAbility();
        controls.Player.DefenceAbility.performed += e => DefenceAbility();
        controls.Player.HealingAbility.performed += e => HealingAbility();
        controls.Player.UltimateAbility.performed += e => UltimateAbility();
        controls.Player.Attack1.performed += e => Attack1();
        controls.Player.Attack2.performed += e => Attack2();
        controls.Player.Attack2.canceled += e => Attack2();


    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        maxJumpHeight = 2f;
        jumpForce = 10f;
        isOnGround = true;
        playerRB.AddForce(Vector3.down);
        crouchedVector = Vector3.Scale(playerObject.transform.localScale, new Vector3(1f, .5f, 1f));
        standingVector = Vector3.Scale(playerObject.transform.localScale, new Vector3(1f, 1f, 1f));
        walkSpeed = GetComponent<PlayerMovement>().Speed;
        sprintSpeed = GetComponent<PlayerMovement>().Speed * sprintModifier;
     }

    void Update()
    {

    }
    private void Jump()
    {
        if (isOnGround)
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
        Walk();
        playerObject.transform.localScale = crouchedVector;
    }
    private void Stand() 
    {
        playerObject.transform.localScale = standingVector;
    }
    private void Sprint()
    {
        Stand();
        GetComponent<PlayerMovement>().Speed = sprintSpeed;
    }
    private void Walk()
    {
        GetComponent<PlayerMovement>().Speed = walkSpeed;
    }
    private void QuickAttack()
    {
        Debug.Log("Quick attacking");
    }
    private void MovementAbility()
    {
        Debug.Log("Movement activated");
    }
    private void HealingAbility()
    {
        Debug.Log("Healing Activated");

    }
    private void DefenceAbility()
    {
        Debug.Log("Defence Activated");

    }
    private void OffenceAbility()
    {
        Debug.Log("Offence Activated");

    }
    private void UltimateAbility()
    {
        Debug.Log("Using Ultimate Ability!");

    }
    private void Attack1()
    {
        if (this.GetComponent<PlayerScript>().Gun.GetComponent<Gun>() != null)
        {
            this.GetComponent<PlayerScript>().Gun.GetComponent<Gun>().WeaponLogic();
        }
        else
        {
            Debug.Log("No Weapon to attack with");

        }        
    }
    private void Attack2()
    {
        this.GetComponent<PlayerScript>().Gun.GetComponent<Gun>().AimLogic();
    }
}

