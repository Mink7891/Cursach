using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prodavets : MonoBehaviour
{
    public string[] say;
    public AudioClip[] clips;
    public AudioSource audioSource;
    public void Dialog()
    {
        GameObject manager = GameObject.Find("DialogManager");
        StartCoroutine(manager.GetComponent<DialogManagerKB>().StartDialog(say, clips, audioSource));
    }
}
