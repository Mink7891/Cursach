using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Ksenich : MonoBehaviour
{
    private GameObject player;
    public GameObject book;
    public float hp;
    private Animator anim;
    private int countBook = 0;
    private bool canShoot = true;
    public RectTransform healthBar;
    public int damage;
    private NavMeshAgent agent;
    public AudioSource walkSource;
    public Dialog[] dialog;
    private bool isWalking = false;
    public bool isScene = true;
    public EndStageTriggerKsen endSceneTrigger;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    public void HaveDamage(int damagePlayer)
    {
        if (hp<=0)
        {
            isWalking = true;
            endSceneTrigger.isTrigger = true;
           
        }
        hp -= damagePlayer;
        float hpLos = (float)damagePlayer / hp;
        Vector2 currentOffsetMax = healthBar.offsetMax;
        Vector2 currentOffsetMin = healthBar.offsetMin;

        currentOffsetMax.y -= currentOffsetMax.y * hpLos;

        healthBar.offsetMax = currentOffsetMax;
        healthBar.offsetMin = currentOffsetMin;
    }
    private void ShootBook(Vector3 targetPosition)
    {
        GameObject books = Instantiate(book, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - books.transform.position).normalized;
        books.GetComponent<Rigidbody2D>().AddForce(direction * 500f);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 9 && Vector3.Distance(transform.position, player.transform.position) > 5 && !isScene && !isWalking)
        {
            GetComponent<WalkEnemy>().AnimWalk(player.transform, anim);
            Attack();
            agent.SetDestination(player.transform.position);
            walkSource.enabled = true;
        }


      



        else
        { 
            
            if (Vector3.Distance(transform.position, player.transform.position) <= 5 && !isScene && !isWalking)
            {
                anim.SetTrigger("idle");
                walkSource.enabled = false;
                agent.ResetPath();
                Attack();
            }

            else if (isWalking)
            {
                agent.SetDestination(new Vector2(-78.49f, 72.05f));
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
            StartCoroutine(ShootWithDelay(player.transform.position, 0.7f));
        }
        else if (countBook == 3)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke(nameof(DeleteRadiusDamage), 0.5f);
        }
    }

    private void DeleteRadiusDamage()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        countBook = 0;
    }


    public void StartDialog(int index)
    {

        StartCoroutine(dialog[index].dialog.GetComponent<DialogManager>().StartDialog(dialog[index].namePers, dialog[index].say, dialog[index].clips, dialog[index].audioSource, gameObject, dialog[index].img));

    }
}
