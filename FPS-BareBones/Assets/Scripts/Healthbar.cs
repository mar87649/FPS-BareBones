using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private GameObject unit;
    private Slider slider;
    private float unitHealth;

    public Slider Slider { get => slider; set => slider = value; }
    public float UnitHealth { get => unitHealth; set => unitHealth = value; }
    public GameObject Unit { get => unit; set => unit = value; }

    public virtual void Awake()
    {
        slider = GetComponent<Slider>();
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.maxValue = unit.GetComponent<UnitScript>().MaxHealth;
    }
    public virtual void UpdateHealthbar()
    {
        unitHealth = unit.GetComponent<UnitScript>().Health;
        slider.value = unitHealth;        
    }
}
