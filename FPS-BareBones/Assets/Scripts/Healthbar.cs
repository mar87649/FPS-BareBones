using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private GameObject unit;
    float unitHealth;
    void Start()
    {
        slider = GetComponent<Slider>();
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.maxValue = unit.GetComponent<UnitScript>().MaxHealth;

    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.value = unitHealth;
    }
}
