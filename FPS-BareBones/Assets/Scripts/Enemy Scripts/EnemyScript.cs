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

    public delegate void EnemyDeathAction();
    public static event EnemyDeathAction OnEnemyDeath;

    public override void Die()
    {
        //Update score
        //Whow on killfeed
        try
        {
            UIManager.Instance.ScoreBoard.GetComponent<ScoreBoard>().UpdateScore(Points);
            UIManager.Instance.KillFeed.GetComponent<KillFeedLogic>().ShowElement(gameObject);
        }
        catch (Exception e)
        {
            Debug.Log("Could not call on UI Manager" + Environment.NewLine + e.Message);
            Debug.Log("Score Points updated: added " + points + " to score.");
            Debug.Log("Killfeed element shown: " + gameObject.name);
        }

        gameObject.SetActive(false);
        DestroyImmediate(gameObject);
    }
}
