using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float projSpeed = 3f;

    public List<KeyValuePair<float, Vector2>> playerShots;

    private Camera mainCamera;
    private float timer = 0f;


    private void Start()
    {
        playerShots = new List<KeyValuePair<float, Vector2>>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(transform.position);
            GameObject proj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector2 mouseClickPos = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x , mainCamera.ScreenToWorldPoint(Input.mousePosition).y);
            Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);
            Vector2 d = (mouseClickPos - playerLocation).normalized;
            proj.GetComponent<Rigidbody2D>().velocity = d * projSpeed;

            playerShots.Add(new KeyValuePair<float, Vector2>(timer, d * projSpeed));
        }

        timer += Time.deltaTime;
    }
}
