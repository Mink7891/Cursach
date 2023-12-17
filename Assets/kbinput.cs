using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class kbinput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    

    public int sceneToLoad = 3; 

    void OnTriggerStay2D(Collider2D other)
    {
      
         if (other.CompareTag("Player")) // Проверка, что объект, входящий в триггер, имеет тег "Player"
        {
            // Загрузка сцены по имени
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
