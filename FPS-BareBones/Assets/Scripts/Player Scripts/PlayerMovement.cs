using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    public float Speed { get => speed; set => speed = value; }
    [SerializeField] public float jumpForce;
    [SerializeField] private GameObject cameraView;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody playerRB;
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
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        MovePlayerRB();
    }
    private void MovePlayerAxis()
    {
        Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * direction.y, new Vector3(1, 0, 1));
        transform.position += movementVertical * Speed * Time.deltaTime;

        Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * direction.x, new Vector3(1, 0, 1));
        transform.position += movementHorizontal * Speed * Time.deltaTime;
    }

    public void MovePlayerRB()
    {
        Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * direction.x, new Vector3(1, 0, 1));
        Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * direction.y, new Vector3(1, 0, 1));

        playerRB.MovePosition(transform.position + ((movementVertical+movementHorizontal) * Speed * Time.deltaTime));
    }

    public void StopMovement()
    {
        playerRB.MovePosition(transform.position+(Vector3.zero*Time.deltaTime));
    }

}