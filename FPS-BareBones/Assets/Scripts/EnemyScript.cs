using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
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
