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
        GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>().UpdateScore(Points);
        GameObject.Find("Kill Feed").GetComponent<KillFeedLogic>().ShowElement(gameObject);
        gameObject.SetActive(false);
        DestroyImmediate(gameObject);
    }
}
