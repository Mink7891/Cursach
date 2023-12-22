using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kashkin : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    public GameObject book;
    public int hp;
    public static int countBook = 0;
    private bool canShoot = true;
    public int damage;
    private NavMeshAgent agent;
    public RectTransform healthBar;
    public AudioSource walkSource;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void HaveDamage(int damagePlayer)
    {
        hp -= damagePlayer;
        float hpLos = (float)damagePlayer / hp;
        Vector2 currentOffsetMax = healthBar.offsetMax;
        Vector2 currentOffsetMin = healthBar.offsetMin;

        currentOffsetMax.y -= currentOffsetMax.y * hpLos;

        healthBar.offsetMax = currentOffsetMax;
        healthBar.offsetMin = currentOffsetMin;
    }
    private void Update()
    {
        GetComponent<WalkEnemy>().AnimWalk(player.transform, anim);
        if (Vector3.Distance(transform.position, player.transform.position) <= 9 && Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            agent.SetDestination(player.transform.position);
            if (canShoot)
            {
                Attack();
            }
            WalkEnemy.temp = true;
            walkSource.enabled = true;
        }
        else
        {
            agent.ResetPath();
            anim.SetTrigger("idle");
            walkSource.enabled = false;
            WalkEnemy.temp = false;
            if (canShoot && Vector3.Distance(transform.position, player.transform.position) <= 5)
            {
                Attack();
            }
        }
        
    }

    private void ShootBook(Vector3 targetPosition)
    {
        GameObject books = Instantiate(book, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - books.transform.position).normalized;
        books.GetComponent<Rigidbody2D>().AddForce(direction * 600f);
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
            StartCoroutine(ShootWithDelay(player.transform.position, 0.5f));
            countBook = 0;
        }
    }
}
