using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    #region Singleton Pattern
    public static PlayerCamera Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    #endregion
    private void Awake()
    {
        Singleton();
    }
}
