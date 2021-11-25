using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private float recoil;
    [SerializeField] private int clipSize;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private bool automatic;
    [SerializeField] private float aimSpeed = 1f;

    [SerializeField] private Vector3 hipFirePosition;
    [SerializeField] private Vector3 adsPosition;

    [SerializeField] private GameObject bullet;


    #region Variables
    public float Spread { get; set; }
    public float Recoil { get => recoil; set => recoil = value; }
    public int ClipSize { get => clipSize; set => clipSize = value; }
    public float ReloadSpeed { get => reloadSpeed; set => reloadSpeed = value; }
    public bool Automatic { get => automatic; set => automatic = value; }
    public Vector3 HipFirePosition { get => hipFirePosition; set => hipFirePosition = value; }
    public Vector3 AdsPosition { get => adsPosition; set => adsPosition = value; }
    public float AimSpeed { get => aimSpeed; set => aimSpeed = value; }
    public GameObject Bullet { get => bullet; set => bullet = value; }



    private float nextTimeToFire = 0f;
    public float adsZoom = 2f;
    private bool ads = false;
    private bool shooting = false;
    #endregion

    public override void Primary()
    {
        base.Primary();
        shooting = !shooting;
        if (shooting && !automatic)
        {
            Shoot();
        }
    }
    private void Update()
    {
        if (shooting && automatic && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / AttackRate;
            Shoot();
        }
    }
    public override void Secondary()
    {
        base.Secondary();
        AimLogic();
    }
    public override void WeaponLogic()
    {

    }
    public void AimDownSights()
    {
        transform.localPosition = Vector3.Lerp(HipFirePosition, AdsPosition, AimSpeed);
        Parent.GetComponent<UnitScript>().ChangeFOV(FOV / adsZoom);
        //POV.GetComponent<Camera>().fieldOfView = FOV / adsZoom;
    }
    public void AimHipFire()
    {
        transform.localPosition = Vector3.Lerp(AdsPosition, HipFirePosition, AimSpeed);
        Parent.GetComponent<UnitScript>().ChangeFOV(FOV);
        //POV.GetComponent<Camera>().fieldOfView = FOV;
    }
    public virtual void Shoot()
    {
        FireBullet();
        RaycastHit hit;
        if (Physics.Raycast(POV.transform.position, POV.transform.forward, out hit, Range))
        {
            UnitScript target = hit.transform.GetComponent<UnitScript>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }
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
    public override void SetPositions()
    {
        hipFirePosition = Parent.GetComponent<UnitScript>().HipFirePosition;
        adsPosition = Parent.GetComponent<UnitScript>().AdsPosition;
    }
    public void FireBullet()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        Instantiate(bullet, transform.position+transform.forward, transform.rotation)
            .GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 100, ForceMode.Impulse);
    }
}
