using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : UnitScript
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private int points = 1;



    public float AttackDamage { get => attackDamage; set => attackDamage = value; }
    public int Points { get => points; set => points = value; }

    public override void Die()
    {
        //Update score
        UIManager.Instance.ScoreBoard.GetComponent<ScoreBoard>().IncrementScore(Points); 
        //Show on killfeed
        UIManager.Instance.KillFeed.GetComponent<KillFeedLogic>().ShowElement(gameObject); 
        //destory object
        gameObject.SetActive(false);
        DestroyImmediate(gameObject);
    }
    public override GameObject InitWeapon(GameObject _weapon)
    {
        base.InitWeapon(_weapon);
        Weapon.GetComponent<Weapon>().POV = PointOfViewObject;
        return Weapon;
    }
    public void FireGun()
    {
        Weapon.GetComponent<Weapon>().Primary();
    }
}
