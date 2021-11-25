using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Damage : Ability
{
    [SerializeField] float damage;
    public float Damage { get => damage; set => damage = value; }

}
