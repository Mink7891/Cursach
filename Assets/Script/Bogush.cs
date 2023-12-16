using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bogush : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public int hp;
    private bool temp = true;
    public int damage;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 14 && Vector3.Distance(transform.position, player.transform.position) > 8)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.transform.position) <= 8)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.GetComponent<Line>().AttackLine(player.transform);
            if (temp)
            {
                StartCoroutine(Damage());
            }
        }
    }

    IEnumerator Damage()
    {
        temp = false;

        //float hpLos = damage / player.GetComponent<Player>().hp;
        //player.GetComponent<Player>().hp -= damage;
        //Vector2 currentOffsetMax = player.GetComponent<Player>().healthBar.offsetMax;
        //Vector2 currentOffsetMin = player.GetComponent<Player>().healthBar.offsetMin;

        //currentOffsetMax.y -= (long)currentOffsetMax.y * hpLos;

        //player.GetComponent<Player>().healthBar.offsetMax = currentOffsetMax;
        //player.GetComponent<Player>().healthBar.offsetMin = currentOffsetMin;


        yield return new WaitForSeconds(1f);
        temp = true;

    }
}
