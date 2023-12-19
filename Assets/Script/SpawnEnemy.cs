using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] points;
    public GameObject pervak;

    private void Awake()
    {
        foreach (Transform point in points)
        {
            GameObject pervakClone = Instantiate(pervak, point.position, Quaternion.identity);

            if (point.name.Contains("Room1"))
            {
                pervakClone.name = "Pervak(Clone)2";
            }
            else if (point.name.Contains("Room2"))
            {
                pervakClone.name = "Pervak(Clone)4";
            }
            else if (point.name.Contains("Room3"))
            {
                pervakClone.name = "Pervak(Clone)6";
            }
            else if (point.name.Contains("Room4"))
            {
                pervakClone.name = "Pervak(Clone)8";
            }
            else if (point.name.Contains("Room5"))
            {
                pervakClone.name = "Pervak(Clone)10";
            }
        }
    }
}
