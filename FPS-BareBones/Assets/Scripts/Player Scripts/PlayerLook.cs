using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private InputAsset controls;
    private float mouseX, mouseY;
    private float verticalLook = 0f;
    public float verticalClamp = 45;
    public float sensitivity = .1f;
    [SerializeField] private new GameObject camera;
    [SerializeField] private GameObject parent;

    private void Awake()
    {
        controls = new InputAsset();
        controls.Player.MouseX.performed += e => mouseX = e.ReadValue<float>();
        controls.Player.MouseY.performed += e => mouseY = e.ReadValue<float>();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Update()
    {
        LookVertical();
        LookHorizontal();
    }
    //look up / down
    private void LookVertical()
    {
        verticalLook -= mouseY * sensitivity * Time.deltaTime;
        verticalLook = Mathf.Clamp(verticalLook, -verticalClamp, verticalClamp);
        camera.transform.localRotation = Quaternion.Euler(verticalLook, 0f, 0f);
    }

    //look left / right  
    private void LookHorizontal()
    {
        transform.Rotate(Vector3.up * mouseX * sensitivity * Time.deltaTime);
    }
}