using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private void ClearPointData()
    {
        for (int i = 1; i < 6; i++)
        {
            PlayerPrefs.DeleteKey("Point" + i);
            PlayerPrefs.Save();
        }

    }
    private void Update()
    {
        GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + 1250 * Time.fixedDeltaTime);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (collision.gameObject.CompareTag("Pervak"))
            {
                collision.gameObject.GetComponent<TrainPervak>().hp -= 25;
                if (collision.gameObject.GetComponent<TrainPervak>().hp <= 0)
                {
                    Destroy(collision.gameObject);
                }
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Ksenich"))
            {
                collision.gameObject.GetComponent<Ksenich>().HaveDamage(25);
                if (collision.gameObject.GetComponent<Ksenich>().hp <= 0)
                {
                    ClearPointData();
                }
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Bogush"))
            {
                collision.gameObject.GetComponent<Bogush>().HaveDamage(25);
                if (collision.gameObject.GetComponent<Bogush>().hp <= 0)
                {
                    ClearPointData();
                }
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Kashkin"))
            {
                collision.gameObject.GetComponent<Kashkin>().HaveDamage(20);
                if (collision.gameObject.GetComponent<Kashkin>().hp <= 0)
                {
                    Destroy(collision.gameObject);
                }
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Pervak"))
            {
                collision.gameObject.GetComponent<Pervak>().hp -= 25;
                if (collision.gameObject.GetComponent<Pervak>().hp <= 0)
                {
                    Destroy(collision.gameObject);
                }
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Decor"))
        {
            Destroy(gameObject);
        }
    }
}
