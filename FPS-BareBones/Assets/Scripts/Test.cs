using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] GameObject parent;
    [SerializeField] float range;

    
    private void Update()
    {

    }
    private void Start()
    {

    }

    public List<GameObject> SpawnXTimes(GameObject spawnee, int num = 1)
    {
        List<GameObject> spawnedList = new List<GameObject>();
        for (int i = 0; i < num; i++)
        {
            spawnedList.Add(
                Instantiate(spawnee, gameObject.transform)
                );
        }
        return spawnedList;

    }

    public GameObject SpawnInRange(GameObject spawnee, Vector3 center, float range=0)
    {
        GameObject _object = Instantiate(spawnee, gameObject.transform);
        Vector3 spawnPos = new Vector3(Random.Range(0, range), Random.Range(0, range), Random.Range(0, range));
        _object.transform.position = center + spawnPos;
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

    IEnumerator SpawnOverTime(GameObject spawnee, float startTime, float spawnInterval, float endTime, GameObject parent)
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
