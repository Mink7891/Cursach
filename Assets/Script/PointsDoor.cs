using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PointsDoor : MonoBehaviour
{
    public GameObject doors;
    public GameObject spawnEnemy;
    private int index;
    public GameObject boss;
    public static bool createTemp = false;
    public static bool destr = false;

    private void Start()
    {
        index = IsTextAllowed(gameObject.name);

        bool pointRemained = PlayerPrefs.GetInt("Point" + index, 1) == 1;

        if (!pointRemained)
        {
            Destroy(gameObject);
        }
    }

  
    private int IsTextAllowed(string text)
    {

        int result = Convert.ToInt32(Regex.Replace(text, @"[^\d]", ""));

        return result;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("Scene") < 3)
            {
                if (doors.GetComponent<ControlDoor>().points[index - 1].position.x > collision.gameObject.transform.position.x && index != 3 && index != 5)
                {
                    switch (index)
                    {
                        case 1:
                            doors.GetComponent<ControlDoor>().doors[0].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[1].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;

                        case 2:
                            doors.GetComponent<ControlDoor>().doors[2].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[3].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;

                        case 4:
                            doors.GetComponent<ControlDoor>().doors[6].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[7].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;
                    }
                }
                else
                {
                    if (index == 3 && doors.GetComponent<ControlDoor>().points[index - 1].position.y < collision.gameObject.transform.position.y)
                    {
                        doors.GetComponent<ControlDoor>().doors[4].SetActive(true);
                        doors.GetComponent<ControlDoor>().doors[5].SetActive(true);
                        spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                        Destroy(gameObject);
                    }
                    if (index == 5 && doors.GetComponent<ControlDoor>().points[index - 1].position.y < collision.gameObject.transform.position.y)
                    {
                        doors.GetComponent<ControlDoor>().doors[8].SetActive(true);
                        boss.SetActive(true);
                        collision.gameObject.GetComponent<Player>().enabled = false;
                        Destroy(gameObject);
                    }
                }
            }
            else if (PlayerPrefs.GetInt("Scene") == 3)
            {
                if (doors.GetComponent<ControlDoor>().points[index - 1].position.x < collision.gameObject.transform.position.x && index < 3)
                {
                    switch (index)
                    {
                        case 1:
                            doors.GetComponent<ControlDoor>().doors[0].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[1].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;

                        case 2:
                            doors.GetComponent<ControlDoor>().doors[2].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[3].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;
                    }
                }
                else if ((index == 3 || index == 6 || index == 7) && doors.GetComponent<ControlDoor>().points[index - 1].position.y < collision.gameObject.transform.position.y)
                {
                    switch (index)
                    {
                        case 3:
                            doors.GetComponent<ControlDoor>().doors[4].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[5].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;

                        case 6:
                            doors.GetComponent<ControlDoor>().doors[10].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            GameObject.Find("Player").GetComponent<Player>().enabled = false;
                            createTemp = true;
                            Destroy(gameObject);
                            break;

                        case 7:
                            doors.GetComponent<ControlDoor>().doors[11].SetActive(true);
                            GameObject.Find("Player").GetComponent<Player>().enabled = true;
                            destr = true;                            
                            boss.SetActive(true);
                            collision.gameObject.GetComponent<Player>().enabled = false;
                            Destroy(gameObject);
                            break;
                    }
                }
                else if (doors.GetComponent<ControlDoor>().points[index - 1].position.x > collision.gameObject.transform.position.x)
                {
                    switch (index)
                    {
                        case 4:
                            doors.GetComponent<ControlDoor>().doors[6].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[7].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;

                        case 5:
                            doors.GetComponent<ControlDoor>().doors[8].SetActive(true);
                            doors.GetComponent<ControlDoor>().doors[9].SetActive(true);
                            spawnEnemy.GetComponent<SpawnEnemy>().Spawn(index);
                            Destroy(gameObject);
                            break;
                    }
                }
            }
            PlayerPrefs.SetInt("Point" + index, 0);
            PlayerPrefs.Save();
        }
    }
}