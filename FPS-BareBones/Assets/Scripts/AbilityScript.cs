using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript
{
    #region Movement Abilities
    public void Blink()
    {
        //teleports player short distance in any direction
    }

    public void Leap()
    {
        //moves player vertically by alot
        //moves player slightly in direction
    }
    public void Dash()
    {
        //moves player quickly in horizontal direection
    }
    public void MyMethod()
    {
        //moves player forward by x distance
        //player is invulnerable
    }
    #endregion
    #region Healing Abilities

    public void Regen()
    {
        //heals player X amount over Y time
    }
    public void HealiongField()
    {
        //Heals withing a Z range for X amount over Y time
    }
    public void Heal()
    {
        //instantly heals target for X amount
    }
    #endregion
    #region Offence Abilities
    public void DamageOrb()
    {
        //Throw an orb that deals damage
    }
    public void DamageBeam()
    {
        //shoot a beam with a range that deal damagee
    }
    public void DamageFeild()
    {
        //place an AOE field thatt deals damage
    }
    #endregion
    #region Defence Abilities
    public void BuffDefence()
    {
        Debug.Log("Defence is buffed");

    }
    #endregion
    #region Utility Abilities
    public void Utility()
    {
        Debug.Log("Utility used.");

    }
    #endregion
    #region Passive Abilities
    public void PassiveRegen()
    {
        Debug.Log("Passivee regen used");

    }
    #endregion
    #region Role Abilites
    public void SupportRoleAbility()
    {
        Debug.Log("Support passive in use.");
    }
    #endregion



}
