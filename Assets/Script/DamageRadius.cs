using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRadius : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Damage(collision.gameObject, 2f));
            //collision.gameObject.GetComponent<Player>().speed = 5f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(nameof(Damage));
            //collision.gameObject.GetComponent<Player>().speed = 7f;
        }
    }

    IEnumerator Damage(GameObject player, float delay)
    {
        for (int i = 0; i < 3; i++)
        {

            //float hpLos = GetComponentInParent<Ksenich>().damage / player.GetComponent<Player>().hp;
            //player.GetComponent<Player>().hp -= GetComponentInParent<Ksenich>().damage;
            //Vector2 currentOffsetMax = player.GetComponent<Player>().healthBar.offsetMax;
            //Vector2 currentOffsetMin = player.GetComponent<Player>().healthBar.offsetMin;

            //currentOffsetMax.y -= (long)currentOffsetMax.y * hpLos;

            //player.GetComponent<Player>().healthBar.offsetMax = currentOffsetMax;
            //player.GetComponent<Player>().healthBar.offsetMin = currentOffsetMin;

            //player.GetComponent<Player>().hp -= 100;
            yield return new WaitForSeconds(delay);
        }
    }
}
