using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // ������ �� ������
    private NavMeshAgent agent; // ��������� NavMeshAgent ��� ���������
    private Vector3 randomDirection; // ��������� ����������� ��� ��������
    private float changeDirectionTimer; // ������ ��� ����� �����������
    private float minChange = 3f; // ����������� ����� �� ����� �����������
    private float maxChange = 8f; // ������������ ����� �� ����� �����������

    // ����� Start ���������� ����� ������ ����������� �����
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // �������� ��������� NavMeshAgent
        ChangeDirection(); // ������������� ��������� ����������� ��������
    }

    // ����� Update ���������� ���� ��� �� ����
    void Update()
    {
        // ���� ���������� �� ������ ������ 5 ������
        if (Vector3.Distance(transform.position, player.position) <= 5f)
        {
            agent.SetDestination(player.position); // ������������� ����� ������� ������
        }
        else
        {
            changeDirectionTimer -= Time.deltaTime; // ��������� ������ ����� �����������

            // ���� ������ ����� ����������� �����
            if (changeDirectionTimer <= 0f)
            {
                ChangeDirection(); // ������ ����������� ��������
            }

            agent.SetDestination(transform.position + randomDirection); // ������������� ����� ��������� �����������
        }
    }

    // ����� ��� ����� ����������� ��������
    void ChangeDirection()
    {
        // ������������� ��������� ����������� � �������� �� -1 �� 1 �� ���� X � Z
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        // ������������� ����� ������ ����� ����������� � �������� �� minChange �� maxChange
        changeDirectionTimer = Random.Range(minChange, maxChange);
    }

}
