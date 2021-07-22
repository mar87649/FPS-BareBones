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
    void Update()
    {
        MovePlayer();
    }
    ///<summary>
    ///Moves player in 3d Space.
    ///<summary>
    private void MovePlayer()
    {
        Vector3 movementVertical = Vector3.Scale(cameraView.transform.forward * direction.y, new Vector3(1, 0, 1));
        transform.position += movementVertical * Speed * Time.deltaTime;

        Vector3 movementHorizontal = Vector3.Scale(cameraView.transform.right * direction.x, new Vector3(1, 0, 1));
        transform.position += movementHorizontal * Speed * Time.deltaTime;
    }
}