using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Vector3 position;
    [SerializeField] private float range;


    public GameObject EnemyToSpawn { get => enemyToSpawn; set => enemyToSpawn = value; }
    public Vector3 Position { get => position; set => position = value; }
    public float Range { get => range; set => range = value; }

    void Start()
    {
    }


    public void StopAllSpawning()
    {
        StopAllCoroutines();
    }
    public void SpawnEnemyRepeating()
    {
        InvokeRepeating("SpawnEnemy", 2, 10);
    }
    public void SpawnEnemy()
    {
        SpawnManager.Instance.SpawnInRange(enemyToSpawn, Position, Range);
    }
}
