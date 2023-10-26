using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Vector3 playerPosition = new Vector3(0f, -3.991798f, 0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDead()
    {
        Time.timeScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // What happens when player touches a slime
        if (collision.collider.CompareTag("Enemy"))
        {
            transform.position = playerPosition;
        }
    }
}
