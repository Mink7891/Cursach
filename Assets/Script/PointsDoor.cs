using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PointsDoor : MonoBehaviour
{
    public GameObject doors;
    private int index; 
    private void Start()
    {
        index = IsTextAllowed(gameObject.name);
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
            if(doors.GetComponent<ControlDoor>().points[index - 1].position.x > collision.gameObject.transform.position.x && index != 3 && index != 5)
            {
                switch (index)
                {
                    case 1:
                        doors.GetComponent<ControlDoor>().doors[0].SetActive(true);
                        break;

                    case 2:
                        doors.GetComponent<ControlDoor>().doors[2].SetActive(true);
                        break;

                    case 4:
                        doors.GetComponent<ControlDoor>().doors[6].SetActive(true);
                        break;
                }
            }
            else
            {
                if (index == 3 && doors.GetComponent<ControlDoor>().points[index - 1].position.y < collision.gameObject.transform.position.y)
                {
                    doors.GetComponent<ControlDoor>().doors[4].SetActive(true);
                }
                if (index == 5 && doors.GetComponent<ControlDoor>().points[index - 1].position.y < collision.gameObject.transform.position.y)
                {
                    doors.GetComponent<ControlDoor>().doors[8].SetActive(true);
                }
            }
            
        }
    }
}
