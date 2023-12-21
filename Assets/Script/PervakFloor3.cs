using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PervakFloor3 : MonoBehaviour
{
    private NavMeshAgent agent;
    public AudioSource runSource;
    private Animator anim;
    private GameObject player;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void Update()
    {

            agent.SetDestination(player.transform.position);
            GetComponent<WalkAnimPervak>().AnimWalk(player.transform, anim);
    }
}
