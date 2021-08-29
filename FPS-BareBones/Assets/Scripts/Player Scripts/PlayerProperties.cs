using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    [SerializeField] private float health;

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float Health { get => health; set => health = value; }
}
