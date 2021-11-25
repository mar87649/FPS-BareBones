using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapScript : Ability_Movement
{
    //change speed
    //move forward
    //jump

    [SerializeField] private float leapSpeed;
    [SerializeField] private float leapForce;


    public float LeapSpeed { get => leapSpeed; set => leapSpeed = value; }
    float initExtraJumpPower;

    public override void PreCastLogic()
    {
        base.PreCastLogic();

        initExtraJumpPower = User.GetComponent<PlayerController>().extraJumpPower;
        User.GetComponent<PlayerController>().extraJumpPower = leapForce;
        User.GetComponent<PlayerController>().LockForward();
        User.GetComponent<PlayerController>().SetAllSpeed(LeapSpeed);
        User.GetComponent<PlayerController>().TriggerJump();
        User.GetComponent<PlayerController>().TriggerJump();
    }
    private bool IsGrounded()
    {
        return User.GetComponent<PlayerController>().isGrounded;
    }
    public override void AbilityLogic()
    {
        if (!Active)
        {
            StartCoroutine(CastLogic());
        }
    }
    public override void PostCastLogic()
    {
        User.GetComponent<PlayerController>().extraJumpPower = initExtraJumpPower;
        User.GetComponent<PlayerController>().ResetJump();
        User.GetComponent<PlayerController>().UnLockDirection();
        User.GetComponent<PlayerController>().ReSetAllSpeed();
        base.PostCastLogic();
    }
    IEnumerator CastLogic()
    {
        PreCastLogic();
        yield return new WaitForSeconds(.1f);
        yield return new WaitUntil(IsGrounded);
        PostCastLogic();
    }
    public override void TestCast()
    {
        base.TestCast();
        StartCoroutine(CastLogic());
    }
}
