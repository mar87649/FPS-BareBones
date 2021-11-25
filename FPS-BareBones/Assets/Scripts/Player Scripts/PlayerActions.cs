using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    //private InputAsset.PlayerActions controls = InputManager.Instance.Controls.Player;
    private bool primaryHold;
    private void Awake()
    {
        //controls = InputManager.Instance.Controls.Player;
        InputManager.Instance.Controls.Player.QuickAttack.performed += e => QuickAttack();
        InputManager.Instance.Controls.Player.MovementAbility.performed += e => MovementAbility();
        InputManager.Instance.Controls.Player.OffenceAbility.performed += e => OffenceAbility();
        //controls.DefenceAbility.performed += e => DefenceAbility();
        InputManager.Instance.Controls.Player.HealingAbility.performed += e => HealingAbility();
        InputManager.Instance.Controls.Player.UltimateAbility.performed += e => UltimateAbility();
        //controls.PrimaryAction.started += e => PrimaryAction();
        InputManager.Instance.Controls.Player.PrimaryAction.performed += e => PrimaryAction();
        InputManager.Instance.Controls.Player.PrimaryAction.canceled += e => PrimaryAction();
        InputManager.Instance.Controls.Player.SecondaryAction.performed += e => SecondaryAction();
        InputManager.Instance.Controls.Player.SecondaryAction.canceled += e => SecondaryAction();
        InputManager.Instance.Controls.Player.Interact.performed += e => Interact();
    }
    public void QuickAttack()
    {
        GameObject PovCam = gameObject.GetComponent<PlayerScript>().PointOfViewObject;
        float Range = 1f;
        float Damage = 5f;
        RaycastHit hit;
        if (Physics.Raycast(PovCam.transform.position, PovCam.transform.forward, out hit, Range))
        {
            UnitScript target = hit.transform.GetComponent<UnitScript>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }
        }
    }
    #region movemnt ability dash
    public void MovementAbility()
    {
        GetComponent<PlayerScript>().MovementAblitity.GetComponent<Ability>().AbilityLogic();
    }
    #endregion
    public void HealingAbility()
    {
        Debug.Log("Healing Activated");
        GetComponent<PlayerScript>().HealingAblitity.GetComponent<Ability>().AbilityLogic();
    }
    public void OffenceAbility()
    {
        Debug.Log("Offence Activated");
        GetComponent<PlayerScript>().OffenceAblitity.GetComponent<Ability>().AbilityLogic();
    }

    #region
    public void UltimateAbility()
    {
        Debug.Log("Using Ultimate Ability!");
        UltimateLogic();
    }
    IEnumerator UltimateLogic()
    {
        GetComponent<PlayerScript>().HealDamage(50);
        GetComponent<PlayerController>().SetAllSpeed(20);
        yield return new WaitForSeconds(10);
        GetComponent<PlayerController>().ReSetAllSpeed();
    }
    #endregion
    public void Interact()
    {
        GameObject povCam = GameObject.FindGameObjectWithTag("PlayerCam");
        float Range = 5;
        if (Physics.Raycast(povCam.transform.position, povCam.transform.forward, out RaycastHit hit, Range))
        {            
            if (hit.transform != null && hit.transform.gameObject.CompareTag("Weapon"))
            {
                hit.transform.gameObject.GetComponent<Weapon>().InteractLogic();
            }
        }
    }
    public void PrimaryAction()
    {
        Debug.Log(GetComponent<PlayerScript>().Weapon.
            GetComponent<Weapon>().name);

        GetComponent<PlayerScript>().Weapon.
            GetComponent<Weapon>().Primary();
    }
    public void SecondaryAction()
    {
        GetComponent<PlayerScript>().Weapon.
            GetComponent<Weapon>().Secondary();
    }
}

