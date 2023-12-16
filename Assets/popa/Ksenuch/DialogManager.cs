using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI nameText;
    private Queue<string> sentences;
    public GameObject dialogWindow;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        dialogWindow.SetActive(true);
        nameText.text = dialog.name;
        sentences.Clear();

        foreach(string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();


    }


    public void DisplayNextSentence()
    {
        if (sentences.Count ==0 )
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }


    public void EndDialog()
    {
        dialogWindow.SetActive(false);
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            DisplayNextSentence();
        }
    }
}
