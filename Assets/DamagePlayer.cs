using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private GameObject endCanvas;
    private GameObject losePanel;

    private void Awake()
    {
        endCanvas = GameObject.Find("EndCanvas");
        losePanel = endCanvas.transform.Find("LosePanel").gameObject;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().enemySpawned = false;
            collision.gameObject.SetActive(false);

            losePanel.SetActive(true);
        }
    }
}
