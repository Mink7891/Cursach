using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog 
{
   

    public GameObject dialog;
    public string namePers;
    [TextArea(3, 10)]
    public string[] say;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public Sprite img;
}
