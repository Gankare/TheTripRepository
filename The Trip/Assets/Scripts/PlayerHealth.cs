using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Vector3 playerPosition = new Vector3(0f, -3.991798f, 0f);
    Rigidbody2D rb2D;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void PlayerDead()
    {
        this.GetComponent<Movement>().enabled = false;
        rb2D.velocity = Vector3.zero;
        animator.SetTrigger("Dying");
        Invoke("ReloadSceneOnDeath", 3);
    }

    public void ReloadSceneOnDeath()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // What happens when player touches a slime
        if (collision.collider.CompareTag("Enemy"))
        {
            PlayerDead();
        }
    }
}
