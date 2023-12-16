using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pervak : MonoBehaviour
{
    private GameObject player;
    private bool isStop = true;
    private bool isAttack = true;
    public int speed;
    public int damage;
    public int hp;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){isStop = false;}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { isStop = true; }
    }

    bool IsWallBetween(Vector3 start, Vector3 end)
    {
        int layerMask = ~LayerMask.GetMask("EnemyLayer");
        RaycastHit2D hit = Physics2D.Raycast(start, (end - start).normalized, Vector2.Distance(start, end), layerMask);

        return hit.collider != null && hit.collider.CompareTag("Wall");
    }

    IEnumerator Attack()
    {
        isAttack = false;
        player.GetComponent<Player>().HaveDamage(damage);
        yield return new WaitForSeconds(1f);
        isAttack = true;
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 10f && !IsWallBetween(transform.position, player.transform.position) && isStop)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (!isStop)
        {
            if (isAttack) { StartCoroutine(Attack()); }
        }
    }


}
