using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjStreet : MonoBehaviour
{
    public GameObject wall;
    public GameObject kb_trigger;
    void Update()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            if (PlayerPrefs.GetInt("Scene") != 0)
            {
                if (PlayerPrefs.GetInt("Scene") == 8){ wall.SetActive(false); }
                else{ wall.SetActive(false); }
                    
                kb_trigger.SetActive(false);
            }
        }
    }
}
