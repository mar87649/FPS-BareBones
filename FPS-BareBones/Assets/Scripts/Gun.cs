using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Gun : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private float recoil;
    [SerializeField] private int clipSize;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject povCam;
    [SerializeField] private bool automatic;
    [SerializeField] private GameObject parent;

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
    public float playerFOV { get; private set; }

    private float nextTimeToFire = 0f;
    [SerializeField] private float aimSpeed = 1f;
    public Bounds parentBounds;
    public Vector3 hipFirePosition;// = new Vector3(1f, 0.05f, 1f);
    public Vector3 adsPosition;// = new Vector3(0f, .15f, 1f);
    public float adsZoom = 2f;
    private bool ads = false;
    #endregion
    private void Start()
    {
        //set player FOV from Camera object
        playerFOV = povCam.GetComponent<Camera>().fieldOfView;
        //set hipfire and ads positions - dependant on parent bounds
        parentBounds = parent.transform.gameObject.GetComponent<Collider>().bounds;
        hipFirePosition = new Vector3(parentBounds.extents.x*2, parentBounds.extents.y*1f, parentBounds.extents.z*2);
        adsPosition = new Vector3(parentBounds.center.x, parentBounds.extents.y*1.15f, parentBounds.extents.z*2);
    }

    void Update()
    {
        
    }
    /// <summary>
    /// Aim down sights method.
    /// Lerps object from hip fire position to ads position with object aimspeed;
    /// Zooms object PovCam by adsZoom amount.
    /// </summary>
    private void AimDownSights()
    {
        transform.localPosition = Vector3.Lerp(hipFirePosition, adsPosition, aimSpeed);
        povCam.GetComponent<Camera>().fieldOfView = playerFOV / adsZoom;
    }
    /// <summary>
    /// Aim hip fire method.
    /// Lerps object from ads position to hip fire position with object aim, speed;
    ///  Zooms object PovCam to default.
    /// </summary>
    private void AimHipFire()
    {
        transform.localPosition = Vector3.Lerp(adsPosition, hipFirePosition, aimSpeed);
        povCam.GetComponent<Camera>().fieldOfView = playerFOV;
    }
    /// <summary>
    /// Shoot at target by using raycast.ss
    /// Acts upon an object with the target script
    /// </summary>
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PovCam.transform.position, PovCam.transform.forward, out hit, Range))
        {
            UnitScript target = hit.transform.GetComponent<UnitScript>();            
            if (target != null)
            {
                target.Takedamage(Damage);
            }
        }
    }

    /// <summary>
    /// Fire weapon based on automatic or manual
    /// </summary>
    /*    public void WeaponLogic()
        {
            if (automatic)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + fireRate;
                    Shoot();
                }
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }*/
    /*    public void WeaponLogic()
        {
            if (automatic)
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + fireRate;
                    Shoot();
                }
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }*/
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

    /*    public void AimLogic()
        {
            if (Input.GetButton("Fire2"))
            {
                AimDownSights();
            }
            else
            {
                AimHipFire();
            }
        }*/
    public void AimLogic()
    {
        if (!ads)
        {
            ads = true;
            AimDownSights();            
        }
        else
        {
            ads = false;
            AimHipFire();
        }
    }
}
