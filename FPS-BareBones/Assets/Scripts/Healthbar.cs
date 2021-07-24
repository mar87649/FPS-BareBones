using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private GameObject unit;
    float unitHealth;

    void OnEnable()
    {
        UnitScript.OnHealthChange += e => UpdateHealthbar();
    }

    void OnDisable()
    {
        UnitScript.OnHealthChange -= e => UpdateHealthbar();
    }

    private void Awake()
    {
        slider = GetComponent<Slider>();
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.maxValue = unit.GetComponent<UnitScript>().MaxHealth;
    }

    void Update()
    {
        transform.LookAt(GameObject.FindWithTag("Player").transform);
    }
    public void UpdateHealthbar()
    {
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.value = unitHealth;
    }
}
