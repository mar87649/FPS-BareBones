using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    KillFeedElement killfeedElement;
    EnemyScript enemy;
    public void OnKill()
    {
        //show killfeed if inactivce
        GameObject.FindGameObjectWithTag("KillFeed").SetActive(true);
        //set killfeed variables
        //create new killfeed element or unhide existing
        //hide after x seconds
    }

    public void ShowKillOnFeed()
    {

    }

}
