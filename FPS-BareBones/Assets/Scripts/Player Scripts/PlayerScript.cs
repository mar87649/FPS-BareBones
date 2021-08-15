using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : UnitScript
{
    [SerializeField] private GameObject playerBody;
    private void Awake()
    {

    }
    public GameObject PlayerBody { get => playerBody; set => playerBody = value; }

    public override void Die()
    {
        //ToDo - add game over
        Debug.Log("Player Died");

    }
    public GameObject InitWeapon(GameObject weapon)
    {
        if (weapon == null)
        {
            return null;
        }else
        {
            weapon.transform.parent = playerBody.transform;
            Weapon = weapon;
            return weapon;
        }
    }

}
