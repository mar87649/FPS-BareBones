using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Movement : Ability
{
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    public float Distance { get => distance; set => distance = value; }
    public float Speed { get => speed; set => speed = value; }
}
