using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text nameText;
    public GameObject dialogWindow;
    public Image img;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public IEnumerator StartDialog(string namePerson, string[] say,AudioClip[] clips, AudioSource audioSource, GameObject enemy, Sprite image)
    {
        NavMeshAgent enemyNav = enemy.GetComponent<NavMeshAgent>();
        enemyNav.speed = 0;
        dialogWindow.SetActive(true);
        nameText.text = namePerson;
        img.sprite = image;
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
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
        enemyNav.speed = 3;
    }


    public IEnumerator StartDialogStatic(string namePerson, string[] say, AudioClip[] clips, AudioSource audioSource, Sprite image)
    {
      
        dialogWindow.SetActive(true);
        nameText.text = namePerson;
        img.sprite = image;
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
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
       
    }




}
