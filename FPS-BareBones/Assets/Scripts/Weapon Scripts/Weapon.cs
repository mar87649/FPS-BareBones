using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    #region EDITOR FIELDS
    [SerializeField] private float damage;
    [SerializeField] private float range = 1f;
    [SerializeField] private float attackRate;    
    [SerializeField] private GameObject pov;
    [SerializeField] private GameObject parent;
    [SerializeField] private float fov;


    #endregion 

    #region PROPERTIES
    public float Damage { get => damage; set => damage = value; }
    public float Range { get => range; set => range = value; }
    public float AttackRate { get => attackRate; set => attackRate = value; }
    public GameObject POV { get => pov; set => pov = value; }
    public GameObject Parent { get => parent; set => parent = value; }
    public float FOV { get => fov; set => fov = value; }



    //private float nextTimeToFire = 0f;
    #endregion

    #region METHODS
    public virtual void InteractLogic()
    {
    }
    public virtual void Primary()
    {
    }
    public virtual void Secondary()
    {
    }
    public virtual void WeaponLogic()
    {
    }
    public virtual void SetPositions()
    {

    }

    public virtual void SetFOV(float _fov)
    {
        FOV = _fov;
    }
    #endregion


}
