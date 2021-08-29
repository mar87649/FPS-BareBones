using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private InputAsset.PlayerActions controls;
    private bool primaryHold;
    private void Awake()
    {
        controls = InputManager.Instance.Controls.Player;
        controls.QuickAttack.performed += e => QuickAttack();
        controls.MovementAbility.performed += e => MovementAbility();
        controls.OffenceAbility.performed += e => OffenceAbility();
        controls.DefenceAbility.performed += e => DefenceAbility();
        controls.HealingAbility.performed += e => HealingAbility();
        controls.UltimateAbility.performed += e => UltimateAbility();
        controls.Attack1.performed += e => primaryHold = true;
        controls.Attack1.canceled += e => primaryHold = false;
        controls.Attack2.performed += e => Attack2();
        controls.Attack2.canceled += e => Attack2();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        if (primaryHold)
        {
            Attack1();
        }
    }
    private void QuickAttack()
    {
        Debug.Log("Quick attacking");
    }
    private void MovementAbility()
    {
        Debug.Log("Movement activated");
    }
    private void HealingAbility()
    {
        Debug.Log("Healing Activated");

    }
    private void DefenceAbility()
    {
        Debug.Log("Defence Activated");

    }
    private void OffenceAbility()
    {
        Debug.Log("Offence Activated");

    }
    private void UltimateAbility()
    {
        Debug.Log("Using Ultimate Ability!");

    }
    private void Attack1()
    {
        GetComponent<UnitScript>().Weapon.GetComponent<Weapon>().WeaponLogic();
    }
    private void Attack2()
    {
        Debug.Log("Aim down sights");
    }
}

