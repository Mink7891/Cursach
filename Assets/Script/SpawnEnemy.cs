using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] points;
    public GameObject pervak;

    public void Spawn(int index)
    {
        foreach (Transform point in points)
        {
            if (ShouldSpawn(point, index))
            {
                GameObject pervakClone = Instantiate(pervak, point.position, Quaternion.identity);
                pervakClone.name = $"Pervak(Clone){index * 2}";
            }
        }
    }

    private bool ShouldSpawn(Transform point, int index)
    {
        string roomName = point.name;
        return roomName.Contains($"Room{index}") && index >= 1 && index <= 5;
    }
}
