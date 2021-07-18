using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : UnitScript
{
    [SerializeField]private float health;
    public float Health { get => health; set => health = value; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10f;
        }
    }
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
        //ToDo - add game over
    }
}
