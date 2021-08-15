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

    public GameObject SpawnInRange(float range, GameObject spawnee, GameObject parent)
    {
        GameObject _object = Instantiate(spawnee, Vector3.zero, Quaternion.identity, parent.transform);
        Vector3 spawnPos = new Vector3(Random.Range(0, range), Random.Range(0, range), Random.Range(0, range));
        _object.transform.position = parent.transform.position + spawnPos;
        return _object;
    }
    public float NearestFloor(GameObject _object)
    {
        Physics.Raycast(_object.transform.position, Vector3.down, out RaycastHit hit);
        return hit.transform.position.y;
    }
    public void Spawn()
    {

    }
    public void SpawnOverTime(GameObject spawnee, float startTime, float spawnInterval, float endTime, GameObject parent)
    {
        StartCoroutine(OverTimeSpawner(spawnee, startTime, spawnInterval, endTime, parent)); 
    }
    IEnumerator OverTimeSpawner(GameObject spawnee, float startTime, float spawnInterval, float endTime, GameObject parent)
    {
        yield return new WaitForSeconds(startTime);
        float i = startTime;
        while (i < endTime)
        {
            Instantiate(spawnee, parent.transform);
            yield return new WaitForSeconds(spawnInterval);
            i += spawnInterval;
        }
    }
}
