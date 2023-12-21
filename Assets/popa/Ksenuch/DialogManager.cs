using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text nameText;
    public GameObject dialogWindow;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public IEnumerator StartDialog(string namePerson, string[] say, AudioSource[] audioSource)
    {
        dialogWindow.SetActive(true);
        nameText.text = namePerson;
        int i = 0;
        while (i != say.Length)
        {
            dialogText.text = say[i];
            audioSource[i].Play();
            yield return new WaitForSeconds(audioSource[i].clip.length);
            i++;
        }
        dialogWindow.SetActive(false);
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
