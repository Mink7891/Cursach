using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    public GameObject[] doors;
    public Transform[] points;

    private void Update()
    {
        if (!(GameObject.Find("Pervak(Clone)2")))
        {
            doors[1].SetActive(false);
            doors[0].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)4")))
        {
            doors[3].SetActive(false);
            doors[2].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)6")))
        {
            doors[5].SetActive(false);
            doors[4].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)8")))
        {
            doors[7].SetActive(false);
            doors[6].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)10")) && doors.Length >= 10)
        {
            doors[9].SetActive(false);
            doors[8].SetActive(false);
        }
    }
}
