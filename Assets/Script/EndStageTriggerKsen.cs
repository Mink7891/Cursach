using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndStageTriggerKsen : MonoBehaviour
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

        if (other.CompareTag("Ksenich") && isTrigger)
        {
            isload = true;
            Player playerScript = player.GetComponent<Player>();


            if (playerScript.hp > 900)
            {

                StartDialog(1);
                PlayerPrefs.SetInt("mark2", 5);
            }


            else if (playerScript.hp >= 500)
            {

                StartDialog(2);
                PlayerPrefs.SetInt("mark2", 4);
            }



            else
            {

                StartDialog(3);
                PlayerPrefs.SetInt("mark2", 3);
            }

            PlayerPrefs.Save();


        }








    }


    private void StartDialog(int index)
    {
        GameObject gameObject = GameObject.Find("Ksenich");
        Dialog[] dialog = gameObject.GetComponent<Ksenich>().dialog;
        StartCoroutine(dialog[index].dialog.GetComponent<DialogManager>().StartDialog(dialog[index].namePers, dialog[index].say, dialog[index].clips, dialog[index].audioSource, gameObject, dialog[index].img));
    }
}
