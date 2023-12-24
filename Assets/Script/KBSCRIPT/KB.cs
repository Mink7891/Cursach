using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KB : MonoBehaviour
{
    private bool temp = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !temp)
        {
            GameObject.Find("kb_human").GetComponent<Prodavets>().Dialog();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            temp = true;
        }
    }
}
