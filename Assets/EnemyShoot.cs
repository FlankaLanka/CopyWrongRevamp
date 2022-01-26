using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public enum ShootDirection
    {
        up,
        down,
        left,
        right
    }

    public GameObject bulletPrefab;
    public float cooldown = 5f;
    public float projSpeed = 3f;
    public bool shootAtPlayer = false;
    [Header("Modify if !Shoot at Player")]
    public ShootDirection shotDirection = ShootDirection.up;

    private float timer;
    private Vector2 direction;

    private void Start()
    {
        timer = cooldown;
    }

    private void Update()
    {
        if(timer >= cooldown)
        {
            if(shootAtPlayer)
            {
                ShootShotAtPlayer();
            }
            else
            {
                //set direction for linear shot
                if (shotDirection == ShootDirection.up)
                {
                    direction = Vector2.up;
                }
                else if (shotDirection == ShootDirection.down)
                {
                    direction = Vector2.down;
                }
                else if (shotDirection == ShootDirection.left)
                {
                    direction = Vector2.left;
                }
                else if (shotDirection == ShootDirection.right)
                {
                    direction = Vector2.right;
                }
                ShootShotLinear(direction);
            }
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }


    private void ShootShotLinear(Vector2 d)
    {
        GameObject proj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        proj.GetComponent<Rigidbody2D>().velocity = d * projSpeed;
    }

    private void ShootShotAtPlayer()
    {
        GameObject proj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        GameObject p = GameObject.Find("Player");
        if(p != null)
        {
            Vector2 d = (p.transform.position - transform.position).normalized;
            proj.GetComponent<Rigidbody2D>().velocity = d * projSpeed;
        }

    }
}
