using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Healing : Ability
{
    [SerializeField] private float healAmount;

    public float HealAmount { get => healAmount; set => healAmount = value; }

    public override void Cast()
    {
        Debug.Log("healing..");
        User.GetComponent<UnitScript>().HealDamage(HealAmount);
    }
}
