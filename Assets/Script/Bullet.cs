using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        //if (transform.position.x > 35f || transform.position.x < -35f || transform.position.y > 35f || transform.position.x < -35f)
        //{
        //    DestroyBullet();
        //}
        GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + 1250 * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ksenich"))
        {
            DestroyBullet();
            collision.gameObject.GetComponent<Ksenich>().hp -= 20;
            if (collision.gameObject.GetComponent<Ksenich>().hp <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Bogush"))
        {
            DestroyBullet();
            collision.gameObject.GetComponent<Bogush>().hp -= 20;
            if (collision.gameObject.GetComponent<Bogush>().hp <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Kashkin"))
        {
            DestroyBullet();
            collision.gameObject.GetComponent<Kashkin>().hp -= 20;
            if (collision.gameObject.GetComponent<Kashkin>().hp <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            DestroyBullet();
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
