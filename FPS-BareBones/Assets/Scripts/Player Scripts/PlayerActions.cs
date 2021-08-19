using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;


    private InputAsset controls;
    private Vector3 crouchedVector;
    private Vector3 standingVector;
    private float sprintSpeed;
    private float walkSpeed;
    private float crouchSpeed;
    private float slideSpeed;
    private bool primaryHold;
    private void Awake()
    {
        controls = new InputAsset();        
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
        controls.Player.Attack1.performed += e => primaryHold = true;
        controls.Player.Attack1.canceled += e => primaryHold = false;
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
        crouchedVector = Vector3.Scale(playerObject.transform.localScale, new Vector3(1f, .5f, 1f));
        standingVector = Vector3.Scale(playerObject.transform.localScale, new Vector3(1f, 1f, 1f));
        walkSpeed = GetComponent<PlayerScript>().Speed;
        sprintSpeed = GetComponent<PlayerScript>().Speed * GetComponent<PlayerScript>().SprintModifier;
        crouchSpeed = GetComponent<PlayerScript>().Speed * GetComponent<PlayerScript>().CrouchModifier;
        slideSpeed = GetComponent<PlayerScript>().Speed * GetComponent<PlayerScript>().SlideModifier;
    }

    void Update()
    {
        if (primaryHold)
        {
            Attack1();
        }
    }
    private void Jump()
    {
        GetComponent<PlayerScript>().StandPlayerControler();
        GetComponent<PlayerMovement>().JumpPlayer();
    }
    private void Crouch()
    {
        GetComponent<PlayerScript>().Speed = crouchSpeed;
        GetComponent<PlayerScript>().CrouchPlayerControler();
        playerObject.transform.localScale = crouchedVector;
    }
    private void Stand() 
    {
        GetComponent<PlayerScript>().StandPlayerControler();
        playerObject.transform.localScale = standingVector;
    }
    private void Sprint()
    {
        Stand();
        GetComponent<PlayerScript>().IsSprinting = true;
        GetComponent<PlayerScript>().Speed = sprintSpeed;
    }
    public void Slide()
    {
        if (GetComponent<PlayerScript>().IsSprinting)
        {
            GetComponent<PlayerScript>().Speed = slideSpeed;
        }
    }
    private void Walk()
    {
        GetComponent<PlayerScript>().IsSprinting = true;
        GetComponent<PlayerScript>().StandPlayerControler();
        GetComponent<PlayerScript>().Speed = walkSpeed;
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
        if (GetComponent<PlayerScript>().Weapon == null)
        {
            Debug.Log("No WeaponName to attack with");
        }
        else
        {      
            //TODO - Make getting weapon dynamic enough to get any weapon
            GetComponent<PlayerScript>().Weapon.GetComponent<Gun>().WeaponLogic();
        }
    }
    private void Attack2()
    {
        if (this.GetComponent<PlayerScript>().Weapon.GetComponent<Gun>() != null)
        {
            this.GetComponent<PlayerScript>().Weapon.GetComponent<Gun>().AimLogic();
        }
        else
        {
            Debug.Log("No WeaponName to attack with");
        }        
    }
}

