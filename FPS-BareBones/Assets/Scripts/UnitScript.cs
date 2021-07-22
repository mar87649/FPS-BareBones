using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour

{
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private GameObject weapon;

    public float Health { get => health; set => health = value; }
    public GameObject Weapon { get => weapon; set => weapon = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    private void Awake()
    {
        maxHealth = health;
    }

    private void Start()
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
        //ToDo - add game over
    }
}
