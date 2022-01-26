using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour
{
    private List<Vector2> previousMovements;
    private int index = 0;

    /*for clone shoot*******************************/
    public GameObject bulletPrefab;

    private List<KeyValuePair<float, Vector2>> cloneShots;
    private float timer = 0f;
    /***********************************************/


    // Start is called before the first frame update
    void Start()
    {
        previousMovements = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().previousMovements;

        //for clone shoot
        cloneShots = new List<KeyValuePair<float, Vector2>>(GameObject.FindObjectOfType<PlayerShoot>().playerShots);
    }

    // Update is called once per frame
    void Update()
    {
        //travel
        if(index < previousMovements.Count)
        {
            transform.position = previousMovements[index];
            index++;

            //for clone shoot
            if (cloneShots.Count != 0)
            {
                if (timer >= cloneShots[0].Key)
                {
                    GameObject proj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    proj.GetComponent<Rigidbody2D>().velocity = cloneShots[0].Value;
                    cloneShots.RemoveAt(0);
                }
                timer += Time.deltaTime;
            }
            /////////

        }
    }
}
