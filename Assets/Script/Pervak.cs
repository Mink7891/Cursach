using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pervak : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private bool isStop = true;
    public int damage;
    public int hp;
    private NavMeshAgent agent;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){ isStop = false; anim.SetTrigger("bite"); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { isStop = true; anim.SetTrigger("idle"); }
    }

    bool IsWallBetween(Vector3 start, Vector3 end)
    {
        int layerMask = ~LayerMask.GetMask("EnemyLayer");
        RaycastHit2D hit = Physics2D.Raycast(start, (end - start).normalized, Vector2.Distance(start, end), layerMask);

        return hit.collider != null && hit.collider.CompareTag("Wall");
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 10f && !IsWallBetween(transform.position, player.transform.position) && isStop)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.ResetPath();
        }
    }


}
