using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
}
