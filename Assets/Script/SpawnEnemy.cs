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


    private void Start()
    {
        foreach (Transform point in points)
        {
            GameObject pervakClone = Instantiate(pervak, point.position, Quaternion.identity);
            if (point.position.x < -16f && point.position.x > -27f)
            {
                pervakClone.name = "Pervak(Clone)2";
            }
            else if (point.position.x < -34.96f && point.position.x > -47.1f && point.position.y > -3.08f && point.position.y < 8.01f)
            {
                pervakClone.name = "Pervak(Clone)4";
            }
            else if (point.position.x > -51.08f && point.position.x < -31.9f && point.position.y > 13.93f && point.position.y < 24.13f)
            {
                pervakClone.name = "Pervak(Clone)6";
            }
        }
    }
}
