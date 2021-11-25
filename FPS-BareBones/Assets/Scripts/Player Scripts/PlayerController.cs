using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using System;
public class PlayerController : BaseFirstPersonController
{
    [Tooltip("Speed.")]
    [SerializeField]
    private float playerSpeed;
    private bool lockDirection = false;
    private bool isFlying { get; set; }


    public float PlayerSpeed { get => playerSpeed; set => playerSpeed = value; }

    public override void Awake()
    {

        base.Awake();
        InputManager.Instance.Controls.Player.Jump.started += e => jump = true;
        InputManager.Instance.Controls.Player.Jump.performed += e => jump = true;
        InputManager.Instance.Controls.Player.Jump.canceled += e => jump = false;

        InputManager.Instance.Controls.Player.Sprint.started += e => run = true;
        InputManager.Instance.Controls.Player.Sprint.performed += e => run = true;
        InputManager.Instance.Controls.Player.Sprint.canceled += e => run = false;

        InputManager.Instance.Controls.Player.Crouch.started += e => crouch = true; 
        InputManager.Instance.Controls.Player.Crouch.performed += e => crouch = true; 
        InputManager.Instance.Controls.Player.Crouch.canceled += e => crouch = false; 

        InputManager.Instance.Controls.Menus.PauseMenu.performed += e => pause = !pause;
    }
    private void Start()
    {
        ReSetAllSpeed();
    }
    protected override void HandleInput()
    {
        moveDirection = new Vector3
        {
            x = InputManager.Instance.Controls.Player.Movement.ReadValue<Vector2>().x,
            y = 0.0f,
            z = InputManager.Instance.Controls.Player.Movement.ReadValue<Vector2>().y
        };     
    }
    protected override void Move()
    {
        // Move with acceleration and friction
        var desiredVelocity = CalcDesiredVelocity();

        var currentFriction = isGrounded || isFlying ? groundFriction : airFriction;
        var currentBrakingFriction = useBrakingFriction ? brakingFriction : currentFriction;

        movement.Move(desiredVelocity, speed, acceleration, deceleration, currentFriction,
            currentBrakingFriction, !allowVerticalMovement);

        // Jump logic
        PlayerJumpLogic();
    }
    private void PlayerJumpLogic()
    {
        Jump();
        MidAirJump();
        UpdateJumpTimer();
    }

    #region Movement Methods
    public virtual void SetAllSpeed(float _speed)
    {
        forwardSpeed = _speed;
        backwardSpeed = _speed;
        strafeSpeed = _speed;
    }
    public virtual void SetForwardSpeed(float _speed)
    {
        forwardSpeed = _speed;
        backwardSpeed = 0;
        strafeSpeed = 0;
    }
    public virtual void ReSetAllSpeed()
    {
        forwardSpeed = playerSpeed;
        backwardSpeed = playerSpeed * 0.6f;
        strafeSpeed = playerSpeed * 0.8f;
    }
    public virtual void LockDirection()
    {
        lockDirection = true;
        if (moveDirection.z == 0 && moveDirection.x == 0)
        {
            moveDirection = Vector3.forward;
        }
        else
        {
            moveDirection = new Vector3
            {
                x = moveDirection.x,
                y = 0.0f,
                z = moveDirection.z
            };
        }
    }
    public virtual void LockForward()
    {
        lockDirection = true;
        moveDirection = Vector3.forward;
    }
    public virtual void UnLockDirection()
    {
        lockDirection = false;
    }
    public void EnterHoverState()
    {
        // Enter Hover state

        allowVerticalMovement = true;
        airControl = 1.0f;

        isFlying = true;
    }
    public void ExitHoverState()
    {
        allowVerticalMovement = false;
        airControl = 0.2f;

        isFlying = false;
    }
    public void TriggerJump()
    {
        jump = true;
        Jump();
        if (jump && !isGrounded)
        {
            MidAirJump();
        }
    }
    public void ResetJump()
    {
        jump = false;
    }
    #endregion
    public override void Update()
    {
        if (!lockDirection)
        {
            // Handle input

            HandleInput();
        }

        // If paused, return

        if (isPaused)
            return;
        // if crouching
        CrouchLogic();

        // Update character rotation (if not paused)

        UpdateRotation();

        // Perform character animation (if not paused)

        Animate();
    }

    public void CrouchLogic()
    {
        if (crouch)
        {
            transform.localScale = new Vector3(1, .5f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
