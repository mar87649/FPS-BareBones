using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private InputAsset controls;
    private void Awake()
    {
        controls = new InputAsset();
        controls.Menus.PauseMenu.performed += e => Debug.Log("Hello World");
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }


}
