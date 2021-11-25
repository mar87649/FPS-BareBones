using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.Player = GameObject.FindGameObjectWithTag("Player");
    }
}
