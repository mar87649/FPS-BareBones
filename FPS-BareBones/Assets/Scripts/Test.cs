/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject povCam;
    [SerializeField] private bool automatic;
    [SerializeField] private GameObject parent;

    public float Damage { get => damage; set => damage = value; }
    public float Range { get => range; set => range = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }

    #region Variables
    public GameObject PovCam { get => povCam; set => povCam = value; }
    public bool Automatic { get => automatic; set => automatic = value; }
    public float PlayerFOV { get; private set; }
    public GameObject Parent { get => parent; set => parent = value; }

    private float nextTimeToFire = 0f;
    [SerializeField] private float aimSpeed = 1f;
    public Bounds parentBounds;
    public Vector3 hipFirePosition;// = new Vector3(1f, 0.05f, 1f);
    public Vector3 adsPosition;// = new Vector3(0f, .15f, 1f);
    public float adsZoom = 2f;
    private bool ads = false;
    #endregion
    private void Awake()
    {
        parentBounds = Parent.transform.gameObject.GetComponent<Collider>().bounds;
        PlayerFOV = PovCam.GetComponent<Camera>().fieldOfView;
    }
    private void Start()
    {
        Debug.Log(povCam.name);
        *//*        //Parent = (transform.parent.GetChild((0)).transform.gameObject);
                parentBounds = Parent.transform.gameObject.GetComponent<Collider>().bounds;
                //set player FOV from Camera object
                //PovCam = Parent.transform.parent.GetChild(1).gameObject;
                //PlayerFOV = PovCam.GetComponent<Camera>().fieldOfView;
                PlayerFOV = PovCam.GetComponent<Camera>().fieldOfView;
                //set hipfire and ads positions - dependant on parent bounds*//*
        hipFirePosition = new Vector3(parentBounds.extents.x * 2, parentBounds.extents.y * 1f, parentBounds.extents.z * 2);
        adsPosition = new Vector3(parentBounds.center.x, parentBounds.extents.y * 1.15f, parentBounds.extents.z * 2);
    }

    void Update()
    {

    }

    private void AimDownSights()
    {
        transform.localPosition = Vector3.Lerp(hipFirePosition, adsPosition, aimSpeed);
        povCam.GetComponent<Camera>().fieldOfView = PlayerFOV / adsZoom;
    }
    private void AimHipFire()
    {
        transform.localPosition = Vector3.Lerp(adsPosition, hipFirePosition, aimSpeed);
        povCam.GetComponent<Camera>().fieldOfView = PlayerFOV;
    }
    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(PovCam.transform.position, povCam.transform.forward, out hit, Range))
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
*/