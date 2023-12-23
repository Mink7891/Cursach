using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManagerKB : MonoBehaviour
{
    public TMP_Text dialogText;
    public GameObject dialogWindow;
    public GameObject viborWindow;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public IEnumerator StartDialog(string[] say, AudioClip[] clips, AudioSource audioSource)
    {
        dialogWindow.SetActive(true);
        player.GetComponent<CharacterController>().enabled = false;
        int i = 0;
        while (i != say.Length)
        {
            dialogText.text = say[i];
            audioSource.clip = clips[i];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            i++;
        }
        dialogWindow.SetActive(false);
        viborWindow.SetActive(true);
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void Pivo()
    {
        PlayerPrefs.SetString("Baf", "Bear");
        PlayerPrefs.Save();
        viborWindow.SetActive(false);
    }
    
    public void Energetik()
    {
        PlayerPrefs.SetString("Baf", "Energetik");
        PlayerPrefs.Save();
        viborWindow.SetActive(false);
    }
}

