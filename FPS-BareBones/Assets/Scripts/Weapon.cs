using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float range = 1f;
    [SerializeField] private float fireRate;
    [SerializeField] private float recoil;
    [SerializeField] private int clipSize;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject povCam;
    [SerializeField] private bool automatic;
    [SerializeField] private GameObject parent;
    [SerializeField] private float aimSpeed = 1f;



    #region Variables
    public float Damage { get => damage; set => damage = value; }
    public float Range { get => range; set => range = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Spread { get; set; }
    public float Recoil { get => recoil; set => recoil = value; }
    public int ClipSize { get => clipSize; set => clipSize = value; }
    public float ReloadSpeed { get => reloadSpeed; set => reloadSpeed = value; }
    public GameObject PovCam { get => povCam; set => povCam = value; }
    public bool Automatic { get => automatic; set => automatic = value; }
    public float PlayerFOV { get; private set; }
    public GameObject Parent { get => parent; set => parent = value; }
    public float AimSpeed { get => aimSpeed; set => aimSpeed = value; }

    private float nextTimeToFire = 0f;
    #endregion
    private void Awake()
    {

    }
    private void Start()
    {

    }

    void Update()
    {

    }

    private void AimDownSights()
    {
        Debug.Log("Aim down sights");

    }

    private void AimHipFire()
    {
        Debug.Log("Aim hip fire");

    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(povCam.transform.position, povCam.transform.forward, out hit, Range))
        {
            UnitScript target = hit.transform.GetComponent<UnitScript>();
            if (target != null)
            {
                target.Takedamage(Damage);
            }
        }
    }

    public void WeaponLogic()
    {
        if (automatic)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + fireRate;
                Shoot();
            }
        }
        else
        {
            Shoot();
        }
    }
}
