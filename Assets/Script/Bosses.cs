using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses : MonoBehaviour
{
    public GameObject boss;

    private void Update()
    {
        if (boss.name == "Kashkin")
        {
            if (boss.GetComponent<Kashkin>().hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else if (boss.name == "Bogush")
        {
            if (boss.GetComponent<Bogush>().hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else if (boss.name == "Ksenich")
        {
            if (boss.GetComponent<Ksenich>().hp <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
