using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    public Transform eye;
    public GameObject projectile;
    public bool aim = false;
    public float aimTime = 2;

    Vector2 projectileAngle;
    Vector2 target;
    Vector2 BossPosition;
    float timer = 0;

    void Start()
    {
        BossPosition = transform.position;
    }

    void Update()
    {
        target.x = FindObjectOfType<Movement>().transform.position.x;
        target.y = FindObjectOfType<Movement>().transform.position.y;

        if (aim)
        {
            timer += Time.deltaTime;

            if(timer > aimTime)
            {
                Fire();
                timer = 0;
            }
        }
    }

    private void Fire()
    {
        Instantiate(projectile, eye.position, eye.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aim = false;
        }
    }
}
