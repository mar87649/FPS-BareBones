using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Healthbar healthBar;

    public float Health { get => health; set => health = value; }
    public GameObject Weapon { get => weapon; set => weapon = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public Healthbar HealthBar { get => healthBar; set => healthBar = value; }

    private void Start()
    {
        maxHealth = health;
    }
    public virtual void Takedamage(float damageTaken)
    {
        Health -= damageTaken;
        HealthBar.UpdateHealthbar();
        if (Health <= 0f)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //ToDo - add game over
        return;
    }
}
