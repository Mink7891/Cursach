using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrainPauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public GameObject player;
    public GameObject LoadScreen;

    public void Continue()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        player.GetComponent<PlayerTraining>().enabled = true;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LosdMenu()
    {
        Time.timeScale = 1f;
        LoadScreen.GetComponent<LoadScreen>().Loading(0);
    }

    bool HasObjectWithSubstring(string substring)
    {
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Contains(substring))
            {
                return true;
            }
        }

        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<PlayerTraining>().enabled = false;
            if (PauseGame)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }
}
