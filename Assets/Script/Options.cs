using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    private GameObject audio;
    void Start()
    {
        audio = GameObject.FindWithTag("BG_MUSIC_CREATED");
    }

    public void OnClick()
    {
        audio.GetComponent<SoundVolumControllerComponent>().LoadParam();
    }
}
