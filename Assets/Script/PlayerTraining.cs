using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTraining : MonoBehaviour
{
    public float speedShoot;
    public GameObject bullet;
    public RectTransform healthBar;
    public float hp;

    public GameObject LoadScreen;

    public AudioSource shootSource;
    public AudioSource waterSource;

    public GameObject uiMove;

    public GameObject[] uiDestoyEnemy;
    public string[] text;

    public static bool shootTemp = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        uiMove.SetActive(false);
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

    private void Update()
    {
        if (shootTemp)
        {
            HandleShootingInput();
        }
        if (shootTemp && !(GameObject.FindWithTag("Pervak")))
        {
            StartCoroutine(PlayText());
        }
    }

    private void HandleShootingInput()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 20f;

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldPosition.z = 0f;
            ShootBullet(worldPosition);
        }
    }

    private void ShootBullet(Vector3 targetPosition)
    {
        shootSource.Play();
        GameObject bullett = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - bullett.transform.position).normalized;
        bullett.GetComponent<Rigidbody2D>().AddForce(direction * speedShoot);
    }

    public IEnumerator PlayText()
    {
        uiDestoyEnemy[2].SetActive(false);
        int i = 0;
        foreach (string item in text)
        {
            shootTemp = false;
            uiDestoyEnemy[0].SetActive(true);
            uiDestoyEnemy[0].GetComponent<TMP_Text>().text = item;
            i++;
            if (i == 2)
            {
                uiDestoyEnemy[1].SetActive(true);
            }
            else
            {
                uiDestoyEnemy[1].SetActive(false);
            }
            yield return new WaitForSeconds(4f);
        }

        LoadScreen.GetComponent<LoadScreen>().Loading(0);
    }
}
