using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloneEnemies : MonoBehaviour
{
    [Header("Stats")]
    public float spawnRate; //how many spawns/sec
    public float enemySpeed; //should be super low

    [Space]
    public GameObject enemyPrefab;

    [HideInInspector]
    private float timePassed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timePassed = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && player.GetComponent<PlayerMovement>() != null)
        {
            if(player.GetComponent<PlayerMovement>().enemySpawned)
                BeginSpawn();
        }
    }

    private void BeginSpawn()
    {
        if(timePassed < spawnRate)
        {
            timePassed += Time.deltaTime;
        }
        else
        {
            //spawn code here
            Instantiate(enemyPrefab, transform);
            timePassed = 0f;
        }
    }

}
