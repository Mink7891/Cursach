using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private bool temp;
    private GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        // �������������� ��������� ���� ����� ���� ��������� �� ������ ����������
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.widthMultiplier = 0.1f;

    }
    private void OnEnable()
    {
        temp = true;
    }
    private void OnDisable()
    {
        player.GetComponent<Player>().speedShoot = 700f;
    }
    public void AttackLine(Transform player)
    {
        // ������� ��� �� ������� � ������
        Vector3 start = transform.position;
        Vector3 end = player.position;
        Vector3 directionToPlayer = (end - start).normalized;

        // ���������� ��� � �����
        int layerMask = ~LayerMask.GetMask("EnemyLayer");
        // ��������� ������������ ���� � ���������
        RaycastHit2D hit = Physics2D.Raycast(start, directionToPlayer, Vector2.Distance(start, end), layerMask);
        if (hit.collider!= null && hit.collider.CompareTag("Player"))
        {
            if (temp)
            {
                hit.collider.GetComponent<Player>().speedShoot /= 2f;
                temp = false;
            }
            // ��������� ���������� ����
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, start);
          
            lineRenderer.SetPosition(1, hit.point);
        }
    }
}
