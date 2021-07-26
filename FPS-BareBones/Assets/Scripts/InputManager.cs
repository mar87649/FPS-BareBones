 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputAsset controls;
    public static InputManager Instance { get; private set; }
    private void Awake()
    {
        Singleton();
        controls = new InputAsset();

        controls.Menus.PauseMenu.performed += e => UIManager.Instance.Logic(); ;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
