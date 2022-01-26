using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerShootNet : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public float projSpeed = 3f;

    public List<KeyValuePair<float, Vector2>> playerShots;

    public Camera mainCamera; //camera in child
    private float timer = 0f;


    private void Start()
    {
        playerShots = new List<KeyValuePair<float, Vector2>>();
        //mainCamera = gameObject.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CmdPlayerShoot();
        }

        timer += Time.deltaTime;
    }

    [Command]
    private void CmdPlayerShoot()
    {
        //command tells server to process the client request

        //also validate logic here -> check if cheating

        RpcPlayerShoot();
    }


    [ClientRpc]
    private void RpcPlayerShoot()
    {
        //here is where you shoot bullet
        //server sends all clients the info that bullet is shot

        GameObject proj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector2 mouseClickPos = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 playerLocation = new Vector2(transform.position.x, transform.position.y);
        Vector2 d = (mouseClickPos - playerLocation).normalized;
        proj.GetComponent<Rigidbody2D>().velocity = d * projSpeed;
        playerShots.Add(new KeyValuePair<float, Vector2>(timer, d * projSpeed));
    }
}
