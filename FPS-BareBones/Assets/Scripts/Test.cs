using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private float health;
    public float Health { get => health; set => health = value; }
    // Update is called once per frame
    void Update()
    {

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
        Destroy(gameObject);
    }
}