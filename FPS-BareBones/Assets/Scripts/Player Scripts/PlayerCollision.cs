using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            //Take Damage health -= 10f;
            float damageTaken = hit.gameObject.GetComponent<EnemyScript>().AttackDamage;
            GetComponent<PlayerScript>().Takedamage(damageTaken);
        }
        if (hit.gameObject.CompareTag("Floor"))
        {
            GetComponent<PlayerScript>().IsOnGround = true;
        }
    }
}
