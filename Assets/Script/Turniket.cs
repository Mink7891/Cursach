using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turniket : MonoBehaviour
{
    public GameObject yesTurnik;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            gameObject.SetActive(false);
            yesTurnik.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
