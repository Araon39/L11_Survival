using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    // �������� �������� ������
    public float moveSpeed;

    // ������ ��� �������� ����������� ��������
    private Vector2 m_Move;

    // �����, ���������� ������ ����
    void Update()
    {
        // �������� ����� Move � ������� ������������ ��������
        Move(m_Move);
    }

    // �����, ���������� ��� ��������� ����� ��������
    public void OnMove(InputAction.CallbackContext context)
    {
        // �������� �������� ����������� �������� �� ����� � ��������� ��� � m_Move
        m_Move = context.ReadValue<Vector2>();
    }

    // ����� ��� ����������� ������
    private void Move(Vector2 direction)
    {
        // ���������, ����� ����������� �������� ���� �� �������
        if (direction.sqrMagnitude < 0.01)
            return;

        // ��������� �������� �������� � ������ �������
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        // ��������� ������� �� ������ ����������� ��������
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);

        // ���������� ������ �� ����������� ���������� � ����������� �����������
        transform.position += move * scaledMoveSpeed;
    }
}
