using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speedShoot;
    public GameObject bullet;
    public RectTransform healthBar;
    public float hp;

    public GameObject LoadScreen;

    public AudioSource shootSource;
    public AudioSource waterSource;
    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerHP"))
        {
            hp = PlayerPrefs.GetFloat("PlayerHP");
            if (hp <= 0)
            {
                LoadScreen.GetComponent<LoadScreen>().Loading(4);
            }
            float damage = 1000f - hp;
            float hpLos = damage / hp;
            Vector2 currentOffsetMax = healthBar.offsetMax;
            Vector2 currentOffsetMin = healthBar.offsetMin;

            currentOffsetMax.y -= (long)currentOffsetMax.y * hpLos;

            healthBar.offsetMax = currentOffsetMax;
            healthBar.offsetMin = currentOffsetMin;
        }
        
        if(PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY"))
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"));
        }
    }
    private void Update()
    {
        HandleShootingInput();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puddle"))
        {
            GetComponent<CharacterController>().moveSpeed /= 3;
            waterSource.Play();
            CharacterController.isWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puddle"))
        {
            CharacterController.isWater = false;
            waterSource.Stop();
            GetComponent<CharacterController>().moveSpeed *= 3;
        }
        if (collision.gameObject.CompareTag("pointDoor"))
        {
            PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
            PlayerPrefs.Save();
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
    }

    public void HaveDamage(int damage)
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        hp -= damage;
        float hpLos = damage / hp;
        Vector2 currentOffsetMax = healthBar.offsetMax;
        Vector2 currentOffsetMin = healthBar.offsetMin;

        currentOffsetMax.y -= (long)currentOffsetMax.y * hpLos;

        healthBar.offsetMax = currentOffsetMax;
        healthBar.offsetMin = currentOffsetMin;

        PlayerPrefs.SetFloat("PlayerHP", hp);
        PlayerPrefs.Save();
    }
    public void LoadGameState()
    {

        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.Save();

    }
    private void ShootBullet(Vector3 targetPosition)
    {
        shootSource.Play();
        GameObject bullett = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector2 direction = (targetPosition - bullett.transform.position).normalized;
        bullett.GetComponent<Rigidbody2D>().AddForce(direction * speedShoot);
    }
}
