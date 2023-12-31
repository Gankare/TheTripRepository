using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LevelTeleport : MonoBehaviour
{
    public GameObject post;
    public GameObject interactText;
    public GameObject mainCamera;
    public Transform player;
    public Transform area1;
    public Transform area2;
    public Transform area3;
    public Transform area4;
    public GameObject highEffect1;
    public GameObject highEffect2;
    public GameObject highEffect3;
    public GameObject highEffect4;
    public static bool cutScene = false;
    private bool inArea;
    private AudioSource audioComponent;

    private void Start()
    {
        audioComponent = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.E))
        {
            if (CameraFollow.currentStage == 1)
            {
                StartCoroutine(HighEffectLevel1());
            }

            if (CameraFollow.currentStage == 2)
            {
                StartCoroutine(HighEffectLevel2());
            }

            if (CameraFollow.currentStage == 3)
            {
                StartCoroutine(HighEffectLevel3());
            }

            if (CameraFollow.currentStage == 4)
            {
                StartCoroutine(HighEffectLevel4());
            }

            CameraFollow.currentStage++;
        }
    }
    public IEnumerator HighEffectLevel1()
    {
        post.SetActive(true);
        audioComponent.PlayOneShot(audioComponent.clip);
        cutScene = true;
        highEffect1.SetActive(true);
        player.position = area1.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(3);
        highEffect1.SetActive(false);
        cutScene = false;
    }
    public IEnumerator HighEffectLevel2()
    {
        audioComponent.PlayOneShot(audioComponent.clip);
        cutScene = true;
        highEffect2.SetActive(true);
        player.position = area2.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(3);
        highEffect2.SetActive(false);
        cutScene = false;
    }
    public IEnumerator HighEffectLevel3()
    {
        audioComponent.PlayOneShot(audioComponent.clip);
        cutScene = true;
        highEffect3.SetActive(true);
        player.position = area3.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(4);
        highEffect3.SetActive(false);
        cutScene = false;
    }
    public IEnumerator HighEffectLevel4()
    {
        audioComponent.PlayOneShot(audioComponent.clip);
        cutScene = true;
        highEffect4.SetActive(true);
        player.position = area4.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        yield return new WaitForSeconds(6);
        highEffect4.SetActive(false);
        cutScene = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactText.SetActive(true);
            inArea = true;
        } 
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inArea = false;
            interactText?.SetActive(false);
        }
    }
}
