using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private GameObject ksenich;
    private int damage;
    private void Start()
    {
        ksenich = GameObject.Find("Ksenich");
        damage = ksenich.GetComponentInParent<Ksenich>().damage;
    }
    private void Update()
    {
        if (transform.position.x > 35f || transform.position.x < -35f || transform.position.y > 35f || transform.position.x < -35f)
        {
            DestroyBullet();
        }
        GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + 1250 * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyBullet();
            
            //float hpLos = damage / collision.gameObject.GetComponent<Player>().hp;
            //collision.gameObject.GetComponent<Player>().hp -= damage;
            //Vector2 currentOffsetMax = collision.gameObject.GetComponent<Player>().healthBar.offsetMax;
            //Vector2 currentOffsetMin = collision.gameObject.GetComponent<Player>().healthBar.offsetMin;

            //currentOffsetMax.y -= (long)currentOffsetMax.y * hpLos;

            //collision.gameObject.GetComponent<Player>().healthBar.offsetMax = currentOffsetMax;
            //collision.gameObject.GetComponent<Player>().healthBar.offsetMin = currentOffsetMin;

            if (collision.gameObject.GetComponent<Player>().hp <= 0)
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
