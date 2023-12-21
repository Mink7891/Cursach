using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    

    public string sceneToLoad; // Название сцены, которую нужно загрузить
    public GameObject loadingScreen; // Префаб загрузочного экрана

    public void StartLoad()
    {
        // Вызывается загрузка сцены асинхронно
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // Активируем загрузочный экран
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // Создаем объект для асинхронной загрузки сцены
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        // Ждем, пока сцена не загрузится полностью
        while (!asyncOperation.isDone)
        {
            // Прогресс загрузки от 0.0 до 1.0 доступен через asyncOperation.progress

            yield return null;
        }

        // Выключаем загрузочный экран после завершения загрузки сцены
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }
}
