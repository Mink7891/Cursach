using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCharacter : MonoBehaviour
{
    public Dialog[] dialog;
    public int ending;
    public GameObject endingUI;
    public List<Sprite> imagesEndings;
    public List<string> endingsWords;
    public Image img;
    public TMP_Text textMeshPro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public IEnumerator StartDialog(int index)
    {
        yield return StartCoroutine(dialog[index].dialog.GetComponent<DialogManager>().StartDialogEnding(dialog[index].namePers, dialog[index].say, dialog[index].clips, dialog[index].audioSource, dialog[index].img));
        InitUI(index);
        yield return new WaitForSeconds(5);
        float value = PlayerPrefs.GetFloat("BG_MUSIC");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("BG_MUSIC", value);
        SceneManager.LoadScene(0);


    }


    public void InitUI(int index)
    {
        
        img.sprite = imagesEndings[index];
        textMeshPro.text = endingsWords[index];
        endingUI.SetActive(true);

    }

    
}
