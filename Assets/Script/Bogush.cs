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
    public int speed = 3;
    private NavMeshAgent agent;
    private Animator animator;
    public RectTransform healthBar;
    public AudioSource walkSource;
    public Dialog dialog;
    private void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        float horizontal = Mathf.Clamp(agent.velocity.normalized.x, -1f, 1f);
        float vertical = Mathf.Clamp(agent.velocity.normalized.z, -1f, 1f);
        float speed = agent.velocity.magnitude;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("speed" , speed);

        if (Vector3.Distance(transform.position, player.transform.position) <= 10 && Vector3.Distance(transform.position, player.transform.position) > 5)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            agent.SetDestination(player.transform.position);
            walkSource.enabled = true;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= 5)
        {
            walkSource.enabled = false;
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



    public void StartDialog()
    {
        
        StartCoroutine(dialog.dialog.GetComponent<DialogManager>().StartDialog(dialog.namePers, dialog.say,dialog.clips, dialog.audioSource, gameObject, dialog.img));
        
    }
}
