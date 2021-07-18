using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField]private GameObject player;
    float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        playerHealth = player.GetComponent<PlayerScript>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerScript>().Health;
        slider.value = playerHealth;
    }
}
