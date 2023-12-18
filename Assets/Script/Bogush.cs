using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bogush : MonoBehaviour
{
    private GameObject player;
    public int hp;
    private bool temp = true;
    public int damage;
    private NavMeshAgent agent;
    private void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 10 && Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            agent.SetDestination(player.transform.position);
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= 5)
        {
            GameObject lineObject = transform.GetChild(0).gameObject;

            if (lineObject)
            {
                lineObject.SetActive(true);
                lineObject.GetComponent<Line>().AttackLine();
                if (temp)
                {
                    StartCoroutine(Damage());
                }
            }
            agent.ResetPath();
        }
    }

    IEnumerator Damage()
    {
        temp = false;

        player.GetComponent<Player>().HaveDamage(damage);
        
        yield return new WaitForSeconds(1f);
        temp = true;

    }
}
