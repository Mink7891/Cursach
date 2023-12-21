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
    public AudioSource runSource;
    public AudioSource attackSource;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        runSource.Play();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){ isStop = false; runSource.Stop(); attackSource.Play(); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { isStop = true; runSource.Play(); attackSource.Stop(); }
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
            GetComponent<WalkAnimPervak>().AnimWalk(player.transform, anim);
        }
        else
        {
            agent.ResetPath();
            anim.SetTrigger("bite");
        }
    }


}
