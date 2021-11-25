using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fists : Weapon
{
    public override void Primary()
    {
        Punch();
    }
    public override void Secondary()
    {
        Block();
    }
    public virtual void Punch()
    {
        RaycastHit hit;
        if (Physics.Raycast(POV.transform.position, POV.transform.forward, out hit, Range))
        {
            UnitScript target = hit.transform.GetComponent<UnitScript>();
            if (target != null)
            {
                target.TakeDamage(Damage);
            }
        }
    }
    public void Block()
    {
        Debug.Log("Blocking with fists");
    }

    public void UnBlock()
    {
        Debug.Log("UnBlocking with fists");
    }
}
