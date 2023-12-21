using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwanEnemyTrain : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject uiMove;
    private bool tempSpawn = true;
    private void Update()
    {
        if (uiMove.active == false && tempSpawn)
        {
            enemy.SetActive(true);
            player.GetComponent<TrainingCharacterController>().enabled = false;
            enemy.transform.position = new Vector3(player.transform.position.x + 3f, player.transform.position.y, 0f);
            tempSpawn = false;
        }
    }
}
