using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public Vector2 velocity;
    public Vector2 playerPosition;
    public Vector2 bossPosition;

    void Start()
    {
        bossPosition = new Vector2(GetComponent<BossMovement>().transform.position.x, GetComponent<BossMovement>().transform.position.y);
        
        GetComponent<Rigidbody2D>().velocity = transform.up * 8;
        Destroy(gameObject, 3);
    }

    void Update()
    {
        playerPosition = new Vector2(GetComponent<Movement>().transform.position.x, GetComponent<Movement>().transform.position.y);

        velocity = bossPosition - playerPosition;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerHealth>().PlayerDead();
            Destroy(gameObject);
        }
    }
}
