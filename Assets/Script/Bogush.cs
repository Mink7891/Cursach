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
    private bool isWalking = false;
    public Dialog[] dialog;
    public EndBossScript endSceneTrigger;
    private void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    bool IsWallBetween(Vector3 start, Vector3 end)
    {
        int layerMask = ~LayerMask.GetMask("EnemyLayer");
        RaycastHit2D hit = Physics2D.Raycast(start, (end - start).normalized, Vector2.Distance(start, end), layerMask);

        return hit.collider != null && hit.collider.CompareTag("Decor");
    }


    private void Update()
    {
        float horizontal = Mathf.Clamp(agent.velocity.normalized.x, -1f, 1f);
        float vertical = Mathf.Clamp(agent.velocity.normalized.z, -1f, 1f);
        float speed = agent.velocity.magnitude;

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
        animator.SetFloat("speed" , speed);

        if (Vector3.Distance(transform.position, player.transform.position) <= 10 && Vector3.Distance(transform.position, player.transform.position) > 5 && !isWalking)
        {
            
            transform.GetChild(0).gameObject.SetActive(false);
            agent.SetDestination(player.transform.position);
            walkSource.enabled = true;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= 5 && !isWalking)
        {
            walkSource.enabled = false;
            GameObject lineObject = transform.GetChild(0).gameObject;

            if (lineObject && !IsWallBetween(gameObject.transform.position, player.transform.position))
            {
                lineObject.SetActive(true);
                lineObject.GetComponent<Line>().AttackLine();
                if (temp)
                {
                    StartCoroutine(Damage());
                }
            }

            else
            {
                if (IsWallBetween(gameObject.transform.position, player.transform.position))
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }


            agent.ResetPath();
        }

        else if (isWalking)
        {
            agent.SetDestination(new Vector2(-74.176f, 64.31f));
        }
    }
    public void HaveDamage(int damage)
    {
        if (hp<=0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            isWalking = true;
            endSceneTrigger.isTrigger = true;
           
            
        }
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



    public void StartDialog(int index)
    {

        StartCoroutine(dialog[index].dialog.GetComponent<DialogManager>().StartDialog(dialog[index].namePers, dialog[index].say,dialog[index].clips, dialog[index].audioSource, gameObject, dialog[index].img));
        
    }


}
