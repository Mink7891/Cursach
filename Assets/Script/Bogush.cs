using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bogush : MonoBehaviour
{
    private GameObject player;
    public float hp;
    private bool temp = true;
    public int damage;
    private NavMeshAgent agent;
    public RectTransform healthBar;
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
    public void HaveDamage(int damage)
    {
        hp -= damage;
        float hpLos = damage / hp;
        Vector2 currentOffsetMax = healthBar.offsetMax;
        Vector2 currentOffsetMin = healthBar.offsetMin;

        currentOffsetMax.y -= (long)currentOffsetMax.y * hpLos;


        healthBar.offsetMax = currentOffsetMax;
        healthBar.offsetMin = currentOffsetMin;
    }
    IEnumerator Damage()
    {
        temp = false;

        player.GetComponent<Player>().HaveDamage(damage);
        
        yield return new WaitForSeconds(1f);
        temp = true;

    }
}
