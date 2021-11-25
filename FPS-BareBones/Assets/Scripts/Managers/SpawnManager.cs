using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    #region
    public static SpawnManager Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }   
    #endregion
    private void Awake()
    {
        Singleton();
    }

    public List<GameObject> InstantiateXTimes(int num, GameObject spawnee)
    {
        List<GameObject> spawnedList = new List<GameObject>();
        for (int i = 0; i < num; i++)
        {
            spawnedList.Add(
                Instantiate(spawnee )
                );
        }
        return spawnedList;

    }

    public GameObject SpawnInRange(GameObject spawnee, Vector3 position, float range)
    {
        Vector3 spawnRange = new Vector3(Random.Range(-range, range), Random.Range(0, range), Random.Range(-range, range));
        Vector3 spawnPos = new Vector3(spawnRange.x + position.x, spawnRange.y + position.y+1, spawnRange.z + position.z);
        GameObject _object = Instantiate(spawnee, position, Quaternion.identity);
        _object.transform.position = spawnPos;
        return _object;
    }
    public float NearestFloor(GameObject _object)
    {
        Physics.Raycast(_object.transform.position, Vector3.down, out RaycastHit hit);
        return hit.transform.position.y;
    }
}
