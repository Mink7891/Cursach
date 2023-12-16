using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyRooms : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
    }
}
