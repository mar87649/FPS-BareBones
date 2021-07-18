using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private GameObject enemy;
    float enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        enemyHealth = enemy.GetComponent<EnemyScript>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemyHealth);
        Debug.Log(slider.value); 
        enemyHealth = enemy.GetComponent<EnemyScript>().Health;
        slider.value = enemyHealth;
    }
}

