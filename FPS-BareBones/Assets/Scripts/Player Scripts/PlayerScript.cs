using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : UnitScript
{
    [SerializeField] private bool isOnGround = true;
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private float jumpForce = 1;
    [SerializeField] private float maxJumpHeight = 10;
    [SerializeField] private float speed = 1;
    [SerializeField] private float sprintModifier = 1.5f;
    [SerializeField] private float crouchModifier = 0.5f;
    [SerializeField] private float slideModifier = 1.3f;
    [SerializeField] private float mass = 1;
    [SerializeField] private GameObject playerBody;

    public float JumpForce { get => jumpForce; set => jumpForce = value; }
    public bool IsOnGround { get => isOnGround; set => isOnGround = value; }
    public float MaxJumpHeight { get => maxJumpHeight; set => maxJumpHeight = value; }
    public float Speed { get => speed; set => speed = value; }
    public float SprintModifier { get => sprintModifier; set => sprintModifier = value; }
    public float Mass { get => mass; set => mass = value; }
    public GameObject PlayerBody { get => playerBody; set => playerBody = value; }
    public float CrouchModifier { get => crouchModifier; set => crouchModifier = value; }
    public float SlideModifier { get => slideModifier; set => slideModifier = value; }
    public bool IsSprinting { get => isSprinting; set => isSprinting = value; }

    private void Awake()
    {

    }
    public override void Die()
    {
        //ToDo - add game over
        Debug.Log("Player Died");

    }
    public GameObject InitWeapon(GameObject weapon)
    {
        if (weapon == null)
        {
            return null;
        }else
        {
            weapon.transform.parent = playerBody.transform;
            Weapon = weapon;
            return weapon;
        }
    }

    public void CrouchPlayerControler()
    {
        if (GetComponent<CharacterController>() != null)
        {
            //TODO - posibly exreact as variable
            GetComponent<CharacterController>().height *= 0.75f;
            GetComponent<CharacterController>().center = new Vector3(0, 0.75f, 0);
        }
        else
        {
            Debug.Log("No charachter controler found");
        }
    }
    public void StandPlayerControler()
    {
        if (GetComponent<CharacterController>() != null)
        {
            //TODO - posibly exreact as variable
            GetComponent<CharacterController>().height = 2;
            GetComponent<CharacterController>().center = new Vector3(0, 1, 0);
        }
        else
        {
            Debug.Log("No charachter controler found");
        }
    }

}
