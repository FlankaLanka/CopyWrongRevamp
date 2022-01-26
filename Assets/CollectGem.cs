using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().enemySpawned = true;
            gameObject.SetActive(false);
        }
    }
}