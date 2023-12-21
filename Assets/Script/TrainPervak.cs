using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainPervak : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private bool isStop = true;
    public static bool isCode = true;
    public int damage;
    public int hp;
    private NavMeshAgent agent;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("PlayerTraining");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { isStop = false; anim.SetTrigger("bite"); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { isStop = true; anim.SetTrigger("idle"); }
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 10f && isStop && isCode)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.ResetPath();
        }
    }
}
