using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : UnitScript
{
    [SerializeField] private float attackDamage = 10f;

    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public override void Die()
    {
        DestroyImmediate(gameObject);
    }
}
