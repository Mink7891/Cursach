using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianScript : MonoBehaviour
{


    private DialogTrigger dialog;
    
    void Start()
    {
        dialog = GetComponent<DialogTrigger>();
    }



    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (Input.GetKeyDown(KeyCode.E)) {
    //        dialog.TriggerDialog();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialog.TriggerDialog();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
