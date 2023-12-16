using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void OnEnable()
    {
        player.GetComponent<Player>().HaveDamage(transform.parent.gameObject.GetComponent<Pervak>().damage);
    }
}
