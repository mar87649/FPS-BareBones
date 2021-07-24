using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : UnitScript
{

    public virtual void Die()
    {
        //ToDo - add game over
    }
}
/*
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private GameObject gun;
    public float Health { get => health; set => health = value; }
    public GameObject Gun { get => gun; set => gun = value; }

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
*/
