using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isPlayerNear = false;
    private bool isMove = false;
    private bool isMove2 = false;
    public float moveSpeed = 5f;
    private GameObject player;

    public GameObject text;

    private Transform targetPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().enabled = false;
            player = collision.gameObject;
            text.SetActive(true);
            isPlayerNear = true;
            targetPoint = transform.GetChild(0);
        }
    }
    public void Ebutton()
    {
        isMove = true;
        text.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear)
        {
            isMove = true;
            text.SetActive(false);
        }

        if (isPlayerNear && isMove)
        {
            // ��������� ����������� � �����
            Vector3 direction = targetPoint.position - player.transform.position;

            // ����������� ������ �����������, ����� �������� ���� ����������
            direction.Normalize();

            // ���������� ������ � ����������� �����
            player.transform.Translate(moveSpeed * Time.deltaTime * direction);

            // ���������, ������ �� ����� ������� �����
            if (Vector3.Distance(player.transform.position, targetPoint.position) < 0.1f)
            {
                isMove = false;
                isMove2 = true;

                // ���� ���� ��������� �����, ������������� �� � �������� �������
                if (transform.childCount > 1)
                {
                    targetPoint = transform.GetChild(1);
                }
            }
        }

        if (isPlayerNear && isMove2)
        {
            // ��������� ����������� � �����
            Vector3 direction = targetPoint.position - player.transform.position;

            // ����������� ������ �����������, ����� �������� ���� ����������
            direction.Normalize();

            // ���������� ������ � ����������� �����
            player.transform.Translate(moveSpeed * Time.deltaTime * direction);
        }
    }
}
