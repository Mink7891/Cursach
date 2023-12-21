using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SpawnRunPervak : MonoBehaviour
{
    public GameObject pervak;
    private bool temp = true;
    public IEnumerator Create()
    {
        temp = false;
        for (int i = 0; i < 7; i++)
        {
            int rand = Random.Range(0, 2);
            switch (rand)
            {
                case 0:
                    Instantiate(pervak, new Vector2(-6.96f, 52.85f), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(pervak, new Vector2(1.08f, 52.85f), Quaternion.identity);
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
        PointsDoor.createTemp = false;
    }

    private void Update()
    {
        if (PointsDoor.createTemp && temp)
        {
            StartCoroutine(Create());
        }

        if (PointsDoor.destr && GameObject.Find("PervakFloor3(Clone)"))
        {
            Destroy(GameObject.Find("PervakFloor3(Clone)"));
        }
    }
}
