using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private GameObject user;
    [SerializeField] private float Cooldowwn;
    [SerializeField] private float duration;
    [SerializeField] private AbilittyState state;


    private bool active;

    public GameObject User { get => user; set => user = value; }
    public float Coldown { get => Cooldowwn; set => Cooldowwn = value; }
    public float Duration { get => duration; set => duration = value; }
    public bool Active { get => active; set => active = value; }
    public AbilittyState State { get => state; set => state = value; }

    public virtual void Start()
    {
        if (User == null)
        {
            throw new NotImplementedException("Ability " + this.name + " is not attached to a Unit object");
        }
        state = AbilittyState.Ready;

    }
    public virtual void PreCastLogic()
    {
        state = AbilittyState.Active;
    }
    public virtual void PostCastLogic()
    {
        state = AbilittyState.Complete;

    }
    public virtual void Cast()
    {

    }
    public virtual void AbilityLogic()
    {
        if (state == AbilittyState.Ready)
        {
            StartCoroutine(CastLogic());
        }
    }
    IEnumerator CastLogic()
    {
        Debug.Log("Active");
        PreCastLogic();
        Cast();
        yield return new WaitForSeconds(Duration);
        PostCastLogic();
        Debug.Log("complete");
        StartCoroutine(CoolDownLogic());
    }
    IEnumerator CoolDownLogic()
    {
        Debug.Log("on cooldown");
        state = AbilittyState.OnCoolDown;
        yield return new WaitForSeconds(Cooldowwn);
        state = AbilittyState.Ready;
        Debug.Log("ready");
    }

    public enum AbilittyState
    {
        OnCoolDown, 
        Active,
        Complete,
        Ready
    }

    public virtual void TestCast()
    {

    }

}
