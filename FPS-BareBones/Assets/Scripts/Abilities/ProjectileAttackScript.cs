using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttackScript : Ability_Damage
{
    [SerializeField] GameObject projectile;
    private GameObject temp;

    public GameObject Projectile { get => projectile; set => projectile = value; }

    public override void PreCastLogic()
    {
        base.PreCastLogic();
        GameObject pov = User.GetComponent<UnitScript>().PointOfViewObject;
        float offset = User.GetComponent<UnitScript>().SpawnnedOffset;
        temp = Instantiate(projectile, pov.transform.position + pov.transform.forward * (offset), pov.transform.rotation);
        temp.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*10, ForceMode.Impulse);
    }
    public override void PostCastLogic()
    {
        base.PostCastLogic();
        Destroy(temp, Duration);
    }
}
