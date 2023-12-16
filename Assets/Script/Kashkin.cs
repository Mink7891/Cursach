using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kashkin : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    public GameObject book;
    public float speed;
    public int hp;
    private bool canShoot = true;
    public int damage;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        GetComponent<WalkEnemy>().AnimWalk(player.transform, anim);
        if (canShoot)
        {
            StartCoroutine(ShootWithDelay(player.transform.position, 0.5f));
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ShootBook(Vector3 targetPosition)
    {
        GameObject books = Instantiate(book, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - books.transform.position).normalized;
        books.GetComponent<Rigidbody2D>().AddForce(direction * 1000f);
    }

    private IEnumerator ShootWithDelay(Vector3 targetPosition, float delay)
    {
        canShoot = false;
        ShootBook(targetPosition);
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
