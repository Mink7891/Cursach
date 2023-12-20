using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianScript : MonoBehaviour
{
    public GameObject dialog;
    public string namePers;
    public string[] say;
    public AudioSource[] audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Player>().enabled = false;
            collision.gameObject.GetComponent<CharacterController>().walkSource.Stop();
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            StartCoroutine(dialog.GetComponent<DialogManager>().StartDialog(namePers, say, audioSource));
        }
    }
}
