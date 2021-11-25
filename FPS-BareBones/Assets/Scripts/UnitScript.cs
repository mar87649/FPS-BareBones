using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    [SerializeField] private GameObject pointOfViewObject;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private float spawnnedOffset = 0;
    [SerializeField] private Vector3 hipFirePosition;// = new Vector3(1f, 0.05f, 1f);
    [SerializeField] private Vector3 adsPosition;// = new Vector3(0f, .15f, 1f);
    [SerializeField] private Bounds bounds;



    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject defaultWeapon;
    [SerializeField] private Healthbar healthBar;
    [SerializeField] private GameObject movementAblitity;
    [SerializeField] private GameObject offenceAblitity;
    [SerializeField] private GameObject defenceAblitity;
    [SerializeField] private GameObject healingAblitity;
    [SerializeField] private GameObject untimateAblitity;

    public GameObject PointOfViewObject { get => pointOfViewObject; set => pointOfViewObject = value; }
    public float Health { get => health; set => health = value; }
    public GameObject Weapon { get => weapon; set => weapon = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public Healthbar HealthBar { get => healthBar; set => healthBar = value; }
    public GameObject MovementAblitity { get => movementAblitity; set => movementAblitity = value; }
    public GameObject OffenceAblitity { get => offenceAblitity; set => offenceAblitity = value; }
    public GameObject DefenceAblitity { get => defenceAblitity; set => defenceAblitity = value; }
    public GameObject HealingAblitity { get => healingAblitity; set => healingAblitity = value; }
    public GameObject UntimateAblitity { get => untimateAblitity; set => untimateAblitity = value; }
    public float SpawnnedOffset { get => spawnnedOffset; set => spawnnedOffset = value; }
    public Bounds Bounds { get => bounds; set => bounds = value; }
    public Vector3 HipFirePosition { get => hipFirePosition; set => hipFirePosition = value; }
    public Vector3 AdsPosition { get => adsPosition; set => adsPosition = value; }
    public GameObject DefaultWeapon { get => defaultWeapon; set => defaultWeapon = value; }

    public virtual void Start()
    {
        HealthBar.UpdateHealthbar();
        Bounds = GetComponent<Collider>().bounds;
        SetWeaponPositions();
        weapon = defaultWeapon;
    }
    public virtual void TakeDamage(float damageTaken)
    {
        Health -= damageTaken;
        HealthBar.UpdateHealthbar();
        if (Health <= 0f)
        {
            Die();
        }
    }
    public virtual void HealDamage(float healAmount)
    {
        Health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        HealthBar.UpdateHealthbar();
    }
    public virtual void Die()
    {
        //ToDo - add game over
        return;
    }

    public virtual void PickUpWeapon()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            GameObject weapon = collision.gameObject;
            InitWeapon(weapon);
        }
    }
    public virtual GameObject InitWeapon(GameObject _weapon)
    {
        _weapon.transform.SetParent(gameObject.transform.Find("Inventory"));
        Weapon = _weapon;
        Weapon.transform.localPosition = HipFirePosition;
        Weapon.transform.localRotation = Quaternion.identity;
        Weapon.GetComponent<Weapon>().Parent = gameObject;
        Weapon.GetComponent<Weapon>().SetPositions();
        Weapon.GetComponent<Weapon>().SetFOV(pointOfViewObject.GetComponent<Camera>().fieldOfView);
        return Weapon;
    }

    public void SetWeaponPositions()
    {
        HipFirePosition = new Vector3(Bounds.extents.x * 2f, Bounds.extents.y * 1f, Bounds.extents.z * 2f);
        AdsPosition = new Vector3(Bounds.center.x, Bounds.extents.y * 1.15f, Bounds.extents.z * 2);
    }
    public virtual void ChangeFOV(float _fov)
    {
        PointOfViewObject.GetComponent<Camera>().fieldOfView = _fov;
    }

    public virtual void ResetUnit()
    {
        Health = maxHealth;
        HealthBar.UpdateHealthbar();
        weapon = defaultWeapon;
    }
}
