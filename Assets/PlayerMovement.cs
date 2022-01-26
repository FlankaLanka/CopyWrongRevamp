using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float jumpHeight;

    [HideInInspector]
    public bool enemySpawned = false;
    [HideInInspector]
    public List<Vector2> previousMovements;

    private Rigidbody2D player;
    private bool isGrounded = false;
    private LayerMask groundlayer;


    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        groundlayer = LayerMask.GetMask("Platform");
        previousMovements = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        //stores player movement for enemies later
        if (!enemySpawned)
            previousMovements.Add(transform.position);

        MovePlayer();
    }


    private void MovePlayer()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (Physics2D.Raycast(transform.position - new Vector3(0.55f, 0, 0), Vector2.down, 0.55f, groundlayer)
            || Physics2D.Raycast(transform.position + new Vector3(0.55f, 0, 0), Vector2.down, 0.55f, groundlayer) 
            || Physics2D.Raycast(transform.position, Vector2.down, 0.55f, groundlayer)) 
        {
            isGrounded = true;
        }

        Debug.DrawRay(transform.position - new Vector3(0.55f, 0, 0), Vector2.down * 0.55f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0.55f, 0, 0), Vector2.down * 0.55f, Color.green);
        Debug.DrawRay(transform.position, Vector2.down * 0.55f, Color.green);
    }

}
