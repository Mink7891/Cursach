using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianScript : MonoBehaviour
{


    public DialogTrigger dialog;
    
    void Start()
    {
        dialog = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            dialog.TriggerDialog();
        }
    }
}
