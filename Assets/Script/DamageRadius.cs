using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRadius : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Damage(collision.gameObject, 3f));
            collision.gameObject.GetComponent<CharacterController>().moveSpeed /= 1.5f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(nameof(Damage));
            collision.gameObject.GetComponent<CharacterController>().moveSpeed *= 1.5f;
        }
    }

    IEnumerator Damage(GameObject player, float delay)
    {
        for (int i = 0; i < 3; i++)
        {

            player.GetComponent<Player>().HaveDamage(75);
            yield return new WaitForSeconds(delay);
        }
    }
}
