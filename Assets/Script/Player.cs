using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float speedShoot;
    public GameObject bullet;
    //private GameObject ksenich;
    //private GameObject kashkin;
    //private GameObject bogush;
    public RectTransform healthBar;
    public float hp;
    private void Update()
    {
        HandleShootingInput();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Book"))
        {
            StartCoroutine(Boom());
        }
    }
    private IEnumerator Boom()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.SetActive(false);
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


        //if (GameObject.FindGameObjectWithTag("Ksenich") || GameObject.FindGameObjectWithTag("Bogush") || GameObject.FindGameObjectWithTag("Kashkin"))
        //{
        //    ksenich = GameObject.FindGameObjectWithTag("Ksenich");
        //    bogush = GameObject.FindGameObjectWithTag("Bogush");
        //    kashkin = GameObject.FindGameObjectWithTag("Kashkin");

        //    if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        Vector3 mousePosition = Input.mousePosition;
        //        mousePosition.z = 20f;

        //        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //        worldPosition.z = 0f;
        //        if (GameObject.FindGameObjectWithTag("Ksenich") && Vector3.Distance(transform.position, ksenich.transform.position) < 10f && Vector3.Distance(transform.position, ksenich.transform.position) > 0.5f)
        //        {
        //            ShootBullet(worldPosition);
        //        }
        //        else if (GameObject.FindGameObjectWithTag("Bogush") && Vector3.Distance(transform.position, bogush.transform.position) < 10f && Vector3.Distance(transform.position, bogush.transform.position) > 0.5f)
        //        {
        //            ShootBullet(worldPosition);
        //        }
        //        else if (GameObject.FindGameObjectWithTag("Kashkin") && Vector3.Distance(transform.position, kashkin.transform.position) < 10f && Vector3.Distance(transform.position, kashkin.transform.position) > 0.5f)
        //        {
        //            ShootBullet(worldPosition);
        //        }

        //    }
        //}
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
    private void ShootBullet(Vector3 targetPosition)
    {
        GameObject bullett = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - bullett.transform.position).normalized;
        bullett.GetComponent<Rigidbody2D>().AddForce(direction * speedShoot);
    }
}
