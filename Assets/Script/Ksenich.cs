using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ksenich : MonoBehaviour
{
    private GameObject player;
    public GameObject book;
    public int hp = 100;
    private Animator anim;
    private int countBook = 0;
    private bool canShoot = true;
    //private bool isMoving = true;
    public int damage;
    private NavMeshAgent agent;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void ShootBook(Vector3 targetPosition)
    {
        GameObject books = Instantiate(book, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - books.transform.position).normalized;
        books.GetComponent<Rigidbody2D>().AddForce(direction * 700f);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 13 && Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            GetComponent<WalkEnemy>().AnimWalk(player.transform, anim);
            Attack();
            agent.SetDestination(player.transform.position);
        }
        else
        {
            anim.SetTrigger("idle");
            agent.ResetPath();
            if (Vector3.Distance(transform.position, player.transform.position) <= 5)
            {
                Attack();
            }
        }
    }

    private IEnumerator ShootWithDelay(Vector3 targetPosition, float delay)
    {
        canShoot = false;
        ShootBook(targetPosition);
        countBook++;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
    private void Attack()
    {
        if (canShoot && countBook < 3)
        {
            StartCoroutine(ShootWithDelay(player.transform.position, 0.5f));
        }
        else if (countBook == 3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke(nameof(DeleteRadiusDamage), 0.5f);
        }
    }

    private void DeleteRadiusDamage()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        countBook = 0;
    }
}
