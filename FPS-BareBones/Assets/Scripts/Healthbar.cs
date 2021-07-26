using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private GameObject unit;
    float unitHealth;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.maxValue = unit.GetComponent<UnitScript>().MaxHealth;
    }
    public void UpdateHealthbar()
    {
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.value = unitHealth;        
    }
}
