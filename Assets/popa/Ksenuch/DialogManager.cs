using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text nameText;
    public GameObject dialogWindow;
    public Image img;
    private GameObject player;
    public GameObject fade;
    public AudioClip drawSound;

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
        if (EndBossScript.isload)
        {
            PlayerPrefs.SetFloat("PlayerPosX", 1f);
            PlayerPrefs.SetFloat("PlayerPosY", -5.09f);
            PlayerPrefs.DeleteKey("PlayerHP");
            PlayerPrefs.Save();
            fade.SetActive(true);
            enemy.GetComponent<AudioSource>().clip = drawSound;
            enemy.GetComponent<AudioSource>().enabled = true;
            enemy.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4);
            player.GetComponent<Player>().LoadScreen.GetComponent<LoadScreen>().Loading(2);
        }

        if (EndStageTriggerKsen.isload)
        {
           
            PlayerPrefs.SetFloat("PlayerPosX", -0.94f);
            PlayerPrefs.SetFloat("PlayerPosY", -3.99f);
            PlayerPrefs.DeleteKey("PlayerHP");
            PlayerPrefs.Save();
            fade.SetActive(true);
            enemy.GetComponent<AudioSource>().clip = drawSound;
            enemy.GetComponent<AudioSource>().enabled = true;
            enemy.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(4);
            player.GetComponent<Player>().LoadScreen.GetComponent<LoadScreen>().Loading(3);
        }
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
