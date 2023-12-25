using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndStageKashkin : MonoBehaviour
{
    public bool isTrigger = false;
    private bool animationPlayed = false;
    private GameObject player;
    public static bool isload = false;



    public void Start()
    {

        player = GameObject.Find("Player");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Kashkin") && isTrigger)
        {
            isload = true;
            Player playerScript = player.GetComponent<Player>();


            if (playerScript.hp > 900)
            {

                StartDialog(1);
                PlayerPrefs.SetInt("mark3", 5);
            }


            else if (playerScript.hp >= 500)
            {

                StartDialog(2);
                PlayerPrefs.SetInt("mark3", 4);
            }



            else
            {

                StartDialog(3);
                PlayerPrefs.SetInt("mark3", 3);
            }




        }








    }


    private void StartDialog(int index)
    {
        GameObject gameObject = GameObject.Find("Kashkin");
        Dialog[] dialog = gameObject.GetComponent<Kashkin>().dialog;
        StartCoroutine(dialog[index].dialog.GetComponent<DialogManager>().StartDialog(dialog[index].namePers, dialog[index].say, dialog[index].clips, dialog[index].audioSource, gameObject, dialog[index].img));
    }
}
