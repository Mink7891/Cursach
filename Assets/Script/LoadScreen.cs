using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;

    public Slider slider;

    public void Loading(int index)
    {
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadAsync(index));
    }

    IEnumerator LoadAsync(int index)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(index);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            slider.value = loadAsync.progress;

            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
