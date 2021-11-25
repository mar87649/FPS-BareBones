using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private Rigidbody projectileRB;
    [SerializeField] private float forwardForce;
    [SerializeField] private float upForce;
    [SerializeField] private float mass;
    [SerializeField] private bool gravityAffected;

    public float ForwardForce { get => forwardForce; set => forwardForce = value; }
    public float UpForce { get => upForce; set => upForce = value; }
    public float Mass { get => mass; set => mass = value; }
    public bool GravityAffected { get => gravityAffected; set => gravityAffected = value; }

    private void Awake()
    {
        projectileRB = GetComponent<Rigidbody>();
        transform.parent = null;
        if (!gravityAffected)
        {
            mass = 0;
            projectileRB.useGravity = false;
        }
    }

/*    public virtual void FireProjectile()
    {
        projectileRB.AddRelativeForce(new Vector3(0, upForce - mass, forwardForce), ForceMode.Impulse);
    }*/

    public virtual void FireProjectile()
    {
        transform.DOMove(transform.forward,  2);
    }
}
