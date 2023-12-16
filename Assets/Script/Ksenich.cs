using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ksenich : MonoBehaviour
{
    private GameObject player;
    public GameObject book;
    public float speed;
    private bool temp = false;
    public int hp = 100;
    private Animator anim;
    private int countBook = 0;
    private bool canShoot = true;
    private bool isMoving = true;
    public Transform[] waipoint1;
    public int damage;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision) { if (collision.gameObject.name == "Player") temp = true; }
    private void OnCollisionExit2D(Collision2D collision) { if (collision.gameObject.name == "Player") temp = false; }

    private void ShootBook(Vector3 targetPosition)
    {
        GameObject books = Instantiate(book, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - books.transform.position).normalized;
        books.GetComponent<Rigidbody2D>().AddForce(direction * 1000f);
    }

    bool IsWallBetween(Vector3 start, Vector3 end)
    {
        int layerMask = ~LayerMask.GetMask("EnemyLayer");
        RaycastHit2D hit = Physics2D.Raycast(start, (end - start).normalized, Vector2.Distance(start, end), layerMask);

        return hit.collider != null && hit.collider.CompareTag("Wall");
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= 10f || IsWallBetween(transform.position, player.transform.position))
        {
            if (isMoving) StartCoroutine(MoveToWaypoint());
            return;
        }
        else
        {
            if (temp)
            {
                Attack();
                anim.SetTrigger("idle");
            }
            else
            {
                GetComponent<WalkEnemy>().AnimWalk(player.transform, anim);
                Attack();
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
            StartCoroutine(ShootWithDelay(player.transform.position, 0.3f));
        }
        else if (countBook == 3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke(nameof(DeleteRadiusDamage), 0.5f);
        }
    }
    private IEnumerator MoveToWaypoint()
    {
        isMoving = false;
 
        Transform point = waipoint1[Random.Range(0, waipoint1.Length)];
  
        while (transform.position != point.position)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 10f && !IsWallBetween(transform.position, player.transform.position))
            {
                break;
            }
            transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
            GetComponent<WalkEnemy>().AnimWalk(point, anim);

            yield return null;
        }

        yield return new WaitForSeconds(0.1f);
        anim.SetTrigger("idle");
        yield return new WaitForSeconds(2f);
        isMoving = true;
    }

    private void DeleteRadiusDamage()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        countBook = 0;
    }
}
