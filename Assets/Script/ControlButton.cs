using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("Scene"));
    }

    public void playAgain()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("BG_MUSIC", GameObject.FindWithTag("BG_MUSIC_CREATED").GetComponent<AudioSource>().volume);
        SceneManager.LoadSceneAsync(1);
    }
}
