using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBallScript : MonoBehaviour
{
    [SerializeField] private float damage;
    Rigidbody rb;

    public float Damage { get => damage; set => damage = value; }

    private void OnCollisionEnter(Collision collision)
    {
        if (! collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<UnitScript>().TakeDamage(damage);
        }
    }
}
