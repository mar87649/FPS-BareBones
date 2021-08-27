 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private InputAsset controls;
    public static InputManager Instance { get; private set; }
    public InputAsset Controls { get => controls; private set => controls = value; }

    private void Awake()
    {
        Singleton();
        Controls = new InputAsset();

        Controls.Menus.PauseMenu.performed += e => UIManager.Instance.Logic(); ;
    }
    private void OnEnable()
    {
        Controls.Enable();
    }
    private void OnDisable()
    {
        Controls.Disable();
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
