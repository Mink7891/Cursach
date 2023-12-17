using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Task 
{
    public string taskName;

    [TextArea(3,10)]
    public string[] sentences;
}
