using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    // Скорость движения игрока
    public float moveSpeed;

    // Вектор для хранения направления движения
    private Vector2 m_Move;

    // Метод, вызываемый каждый кадр
    void Update()
    {
        // Вызываем метод Move с текущим направлением движения
        Move(m_Move);
    }

    // Метод, вызываемый при получении ввода движения
    public void OnMove(InputAction.CallbackContext context)
    {
        // Получаем значение направления движения из ввода и сохраняем его в m_Move
        m_Move = context.ReadValue<Vector2>();
    }

    // Метод для перемещения игрока
    private void Move(Vector2 direction)
    {
        // Проверяем, чтобы направление движения было не нулевым
        if (direction.sqrMagnitude < 0.01)
            return;

        // Вычисляем скорость движения с учетом времени
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;

        // Вычисляем поворот на основе направления движения
        var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);

        // Перемещаем игрока на вычисленное расстояние в вычисленном направлении
        transform.position += move * scaledMoveSpeed;
    }
}
