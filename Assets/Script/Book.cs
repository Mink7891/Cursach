using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private GameObject ksenich;
    private int damage;
    private void Awake()
    {
        ksenich = GameObject.Find("Ksenich");
        damage = ksenich.GetComponentInParent<Ksenich>().damage;
    }
    private void Update()
    {
        GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + 1250 * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().HaveDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Decor"))
        {
            Destroy(gameObject);
        }
    }
}
