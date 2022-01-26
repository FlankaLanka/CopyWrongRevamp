using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detect floor and destroy bullet
        //detect hit on player is in other script named DamagePlayer
        if(collision.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
