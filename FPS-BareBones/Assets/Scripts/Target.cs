
using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float health;

    public float Health { get => health; set => health = value; }

    public void Takedamage(float amount)
    {

        Health -= amount;
        if (Health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
