using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Components;

public class DashScript : Ability_Movement
{
    [SerializeField] private float airControl;
    private Vector3 initPos;
    private float prevAirControl;
    public override void PreCastLogic()
    {
        base.PreCastLogic();
        initPos = User.transform.position;
        prevAirControl = User.GetComponent<PlayerController>().airControl;
        User.GetComponent<PlayerController>().EnterHoverState();
        User.GetComponent<PlayerController>().SetAllSpeed(Speed);
        User.GetComponent<PlayerController>().airControl = airControl;
        User.GetComponent<PlayerController>().LockDirection();
    }
    private void Update()
    {
        if (Vector3.Distance(initPos, User.transform.position) == Distance)
        {
            PostCastLogic();
        }
    }
    public override void AbilityLogic()
    {
        base.AbilityLogic();
    }
    public override void PostCastLogic()
    {
        User.GetComponent<PlayerController>().airControl = prevAirControl;
        User.GetComponent<PlayerController>().ReSetAllSpeed();
        User.GetComponent<PlayerController>().UnLockDirection();
        User.GetComponent<PlayerController>().ExitHoverState();
        base.PostCastLogic();
    }
    
}

/*    public override void PreCastLogic()
        {
            base.PreCastLogic();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetAllSpeed(100000);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().airControl = 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().airFriction = 8f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().useGravity = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LockDirection();
        }
        public override void Cast()
        {
            base.Cast();
        }
        public override void PostCastLogic()
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().ReSetAllSpeed();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().airControl = .2f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().airFriction = 0f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().useGravity = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().UnLockDirection();
            base.PostCastLogic();
        }*/
