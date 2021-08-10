using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : Healthbar
{
    void Update()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            transform.LookAt(GameObject.FindWithTag("Player").transform);
        }
    } 
}

