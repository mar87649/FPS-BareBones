using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
public class PlayerController : BaseFirstPersonController
{
    public override void Awake()
    {
        base.Awake();
    }

    protected override void HandleInput()
    {
        InputManager.Instance.Controls.Player.Jump.started += e => jump = true;
        InputManager.Instance.Controls.Player.Jump.performed += e => jump = true;
        InputManager.Instance.Controls.Player.Jump.canceled += e => jump = false;

        InputManager.Instance.Controls.Player.Sprint.started += e => run = true;
        InputManager.Instance.Controls.Player.Sprint.performed += e => run = true;
        InputManager.Instance.Controls.Player.Sprint.canceled += e => run = false;

        InputManager.Instance.Controls.Player.Crouch.started += e => crouch = true;
        InputManager.Instance.Controls.Player.Crouch.performed += e => crouch = true;
        InputManager.Instance.Controls.Player.Crouch.canceled += e => crouch = false;

        moveDirection = new Vector3
        {
            x = InputManager.Instance.Controls.Player.Movement.ReadValue<Vector2>().x,
            y = 0.0f,
            z = InputManager.Instance.Controls.Player.Movement.ReadValue<Vector2>().y
        };

        InputManager.Instance.Controls.Menus.PauseMenu.performed += e => pause = !pause;
    }
}
