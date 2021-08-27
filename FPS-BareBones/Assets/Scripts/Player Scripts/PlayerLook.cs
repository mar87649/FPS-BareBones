using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Components;

public class PlayerLook : MouseLook
{
    public override void LookRotation(CharacterMovement movement, Transform cameraTransform)
    {
        var yaw = InputManager.Instance.Controls.Player.MouseX.ReadValue<float>()
            * lateralSensitivity;
        var pitch = InputManager.Instance.Controls.Player.MouseY.ReadValue<float>()
            * verticalSensitivity;

        var yawRotation = Quaternion.Euler(0.0f, yaw, 0.0f);
        var pitchRotation = Quaternion.Euler(-pitch, 0.0f, 0.0f);

        characterTargetRotation *= yawRotation;
        cameraTargetRotation *= pitchRotation;

        if (clampPitch)
            cameraTargetRotation = ClampPitch(cameraTargetRotation);

        if (smooth)
        {
            // On a rotating platform, append platform rotation to target rotation

            if (movement.platformUpdatesRotation && movement.isOnPlatform && movement.platformAngularVelocity != Vector3.zero)
            {
                characterTargetRotation *=
                    Quaternion.Euler(movement.platformAngularVelocity * Mathf.Rad2Deg * Time.deltaTime);
            }

            movement.rotation = Quaternion.Slerp(movement.rotation, characterTargetRotation,
                smoothTime * Time.deltaTime);

            cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation, cameraTargetRotation,
                smoothTime * Time.deltaTime);
        }
        else
        {
            movement.rotation *= yawRotation;
            cameraTransform.localRotation *= pitchRotation;

            if (clampPitch)
                cameraTransform.localRotation = ClampPitch(cameraTransform.localRotation);
        }

        UpdateCursorLock();
    }

}
/*public class PlayerLook : MonoBehaviour
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
}*/