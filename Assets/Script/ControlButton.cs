using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    public GameObject LoadScreen;
    public GameObject play;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Scene"))
        {
            if (play) { play.SetActive(true); }
            
        }
        else
        {
            if (play) { play.SetActive(false); }
        }
    }
    public void Play()
    {
        LoadScreen.GetComponent<LoadScreen>().Loading(PlayerPrefs.GetInt("Scene"));
    }

    public void playAgain()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("BG_MUSIC", GameObject.FindWithTag("BG_MUSIC_CREATED").GetComponent<AudioSource>().volume);
        LoadScreen.GetComponent<LoadScreen>().Loading(1);
    }
    public void Loos()
    {
        PlayerPrefs.DeleteAll();
        LoadScreen.GetComponent<LoadScreen>().Loading(1);
    }

    public void Training()
    {
        LoadScreen.GetComponent<LoadScreen>().Loading(5);
    }

    public void Exit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
