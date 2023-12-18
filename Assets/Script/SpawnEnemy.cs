using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] points;
    public GameObject pervak;
    //public GameObject ksenich;
    //IEnumerator Start()
    //{
    //    int count_enemy = Random.Range(2, 10);
    //    for (int i = 0; i < count_enemy; i++)
    //    {
    //        int temp = Random.Range(0, 2);
    //        yield return new WaitForSeconds(5f);
    //        if (temp == 0)
    //        {
    //            Instantiate(ksenich, new Vector3(Random.Range(-24f, -14f), Random.Range(-5f, 5f), 0f), Quaternion.identity);
    //        }
    //        else if (temp == 1)
    //        {
    //            Instantiate(ksenich, new Vector3(Random.Range(14f, 24f), Random.Range(-5f, 5f), 0f), Quaternion.identity);
    //        }
    //    }
    //}

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
        }
    }
}
