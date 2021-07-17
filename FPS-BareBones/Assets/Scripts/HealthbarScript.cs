using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    private Slider slider;
    [SerializeField]private GameObject player;
    float playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        playerHealth = player.GetComponent<PlayerStats>().Health;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerHealth);
        Debug.Log(slider.value);

        playerHealth = player.GetComponent<PlayerStats>().Health;
        slider.value = playerHealth;
    }
}
