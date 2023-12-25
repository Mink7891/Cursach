using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class zachetka : MonoBehaviour
{



    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I)) {
            
            for (int i = 1; i <= 3; i++)
            {
                if (PlayerPrefs.HasKey($"mark{i}"))
                {
                    print(PlayerPrefs.GetInt($"mark{i}"));
                }
                
            }
        }
    }


    

}
