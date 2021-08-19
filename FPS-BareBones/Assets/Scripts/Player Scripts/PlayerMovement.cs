using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject cameraView;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private CharacterController playerController;
    private Vector3 jumpVector;
    private InputAsset controls;
    private Vector2 direction;

    private void Awake()
    {
        controls = new InputAsset();
        controls.Player.Movement.performed += e => direction = e.ReadValue<Vector2>();
        controls.Player.Movement.canceled += e => direction = Vector2.zero;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    void FixedUpdate()
    {
        MovePlayerCC();
    }

    public void MovePlayerTranslate()
    {
        Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * direction.y, new Vector3(1, 0, 1));
        transform.position += GetComponent<PlayerScript>().Speed * Time.deltaTime * movementVertical;

        Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * direction.x, new Vector3(1, 0, 1));
        transform.position += GetComponent<PlayerScript>().Speed * Time.deltaTime * movementHorizontal;
    }

    public void MovePlayerRB()
    {
        Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * direction.x, new Vector3(1, 0, 1));
        Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * direction.y, new Vector3(1, 0, 1));

        playerRB.velocity = transform.position + (GetComponent<PlayerScript>().Speed * Time.fixedDeltaTime * (movementVertical+movementHorizontal));
    }
    public void MovePlayerCC()
    {
        Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * direction.x, new Vector3(1, 0, 1));
        Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * direction.y, new Vector3(1, 0, 1));

        playerController.Move(GetComponent<PlayerScript>().Speed * Time.deltaTime * (movementVertical + movementHorizontal + jumpVector) );

        if (jumpVector.y > 0)
        {
            if (transform.position.y > GetComponent<PlayerScript>().MaxJumpHeight)
            {
                //TODO - extract as variable
                jumpVector.y -= 9.8f * GetComponent<PlayerScript>().Mass * Time.deltaTime;
            }
        }

    }

    public void JumpPlayer()
    {
        if (GetComponent<PlayerScript>().IsOnGround)
        {
            jumpVector.y = GetComponent<PlayerScript>().JumpForce;
            GetComponent<PlayerScript>().IsOnGround = false;
        }
    }

    public void StopMovement()
    {
        //playerRB.MovePosition(transform.position+(Vector3.zero*Time.deltaTime));
    }



}