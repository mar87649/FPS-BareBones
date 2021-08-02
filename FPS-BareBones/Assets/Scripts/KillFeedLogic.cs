using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KillFeedLogic : MonoBehaviour
{
    public int amountToPool;
    public List<GameObject> pooledElements;
    public GameObject objectToPool;
    public float elementTimeOut;
    private void Start()
    {
        InitKillFeedElements();
    }
    public void ShowElement(GameObject unit)
    {        
        GameObject.FindGameObjectWithTag("KillFeed").SetActive(true);
        GameObject killfeedElement = GetPooledElement();
        killfeedElement.GetComponent<KillFeedElement>().Text.SetText(unit.name);
        killfeedElement.SetActive(true);
        StartCoroutine(HideElement(killfeedElement, elementTimeOut));
    }
    IEnumerator HideElement(GameObject element, float length)
    {
        yield return new WaitForSeconds(length);
        element.SetActive(false);
    }
    public GameObject GetPooledElement()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledElements[i].activeInHierarchy)
            {
                return pooledElements[i];
            }
        }
        return null;
    }

    public void InitKillFeedElements()
    {
        pooledElements = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool, Vector3.zero, Quaternion.identity, transform.GetChild(0));
            tmp.GetComponent<RectTransform>().localPosition = Vector3.zero;
            tmp.SetActive(false);
            pooledElements.Add(tmp);
        }
    }
}
