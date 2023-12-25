using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    public EndCharacter kashkin;
    public int ending = 0;
    void Start()
    {
        float count = 0;
        for (int i = 1; i <= 3; i++)
        {
            count += PlayerPrefs.GetInt($"mark{i}");

        }

        if (count / 3 >=  4.5f)
        {
            StartCoroutine(kashkin.StartDialog(0));
        }



        else if (count / 3 > 3)
        {
            StartCoroutine(kashkin.StartDialog(1));
        }


        else
        {
            StartCoroutine(kashkin.StartDialog(2));
        }


    }

   
    
    
}
