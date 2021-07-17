using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    public float Speed { get => speed; set => speed = value; }
    [SerializeField] public float jumpForce;
    private Rigidbody playerRB;
    [SerializeField] private GameObject cameraView;
    [SerializeField] private float mouseSensitivity = 10f;
    private float verticalLook = 0f;
    [SerializeField] private float speed;
    float mouseX, mouseY;

    void Start()
    {
        
    }
    void Update()
    {
        MovePlayer();
    }
    ///<summary>
    ///Moves player in 3d Space.
    ///<summary>
    private void MovePlayer()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            // move forward and backward along X and Z axis
            Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * Input.GetAxis("Vertical"), new Vector3(1, 0, 1));
            transform.position += movementVertical * Speed * Time.deltaTime;
            //move left or right according to look direction
            Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * Input.GetAxis("Horizontal"), new Vector3(1, 0, 1));
            transform.position += movementHorizontal * Speed * Time.deltaTime;
        }
    }
}