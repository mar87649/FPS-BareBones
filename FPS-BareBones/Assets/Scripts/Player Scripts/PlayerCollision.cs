using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Take Damage health -= 10f;
            float damageTaken = collision.gameObject.GetComponent<EnemyScript>().AttackDamage;
            GetComponent<PlayerScript>().Takedamage(damageTaken);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //stop movment
            Debug.Log("hit obstacle");

            GetComponent<PlayerMovement>().StopMovement();
        }

    }
}
