using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBoss : MonoBehaviour
{
    private GameObject kashkin;
    private int damage;
    public GameObject boom;
    private void Start()
    {
        kashkin = GameObject.Find("Kashkin");
        damage = kashkin.GetComponentInParent<Kashkin>().damage;
    }
    private void Update()
    {
        GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + 1250 * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Kashkin.countBook < 3)
            {
                collision.gameObject.GetComponent<Player>().HaveDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Player>().HaveDamage(damage * 2);
                Instantiate(boom, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Decor"))
        {
            Destroy(gameObject);
        }
    }
}
