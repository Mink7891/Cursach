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
        }
        if (!(GameObject.Find("Pervak(Clone)4")))
        {
            doors[3].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)6")))
        {
            doors[5].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)8")))
        {
            doors[7].SetActive(false);
        }
        if (!(GameObject.Find("Pervak(Clone)10")) && doors.Length >= 10)
        {
            doors[9].SetActive(false);
        }
    }
}
