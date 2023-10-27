using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    public Image fadeIn;
    public AudioSource audioComponent;
    public List<Transform> checkpoints = new List<Transform>();

    void Start()
    {
        fadeIn.CrossFadeAlpha(1, 0, true);
        StartCoroutine(BlackFadeIn());
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (CameraFollow.currentStage > 1 )
        {
            loadNewScene();
        }
    }
    IEnumerator BlackFadeIn()
    {
        yield return new WaitForSeconds(1);
        fadeIn.CrossFadeAlpha(0, 3, true);
    }
    public void loadNewScene()
    {
        transform.position = checkpoints[CameraFollow.currentStage -1].transform.position;
    }
    public void PlayerDead()
    {
        fadeIn.CrossFadeAlpha(1, 2, true);
        audioComponent.PlayOneShot(audioComponent.clip);
        this.GetComponent<Movement>().enabled = false;
        rb2D.velocity = Vector3.zero;
        animator.SetTrigger("Dying");
        Invoke("ReloadSceneOnDeath", 3);
    }


    public void ReloadSceneOnDeath()
    {
        SceneManager.LoadScene(1);
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
