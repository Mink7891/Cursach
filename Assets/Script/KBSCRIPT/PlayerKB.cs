using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKB : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "doorColider")
        {
            PlayerPrefs.SetInt("Scene", 6);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Street");
        }
    }
}
