using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    private NavMeshAgent agent; // Компонент NavMeshAgent для навигации
    private Vector3 randomDirection; // Случайное направление для движения
    private float changeDirectionTimer; // Таймер для смены направления
    private float minChange = 3f; // Минимальное время до смены направления
    private float maxChange = 8f; // Максимальное время до смены направления

    // Метод Start вызывается перед первым обновлением кадра
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Получаем компонент NavMeshAgent
        ChangeDirection(); // Устанавливаем начальное направление движения
    }

    // Метод Update вызывается один раз за кадр
    void Update()
    {
        // Если расстояние до игрока меньше 5 единиц
        if (Vector3.Distance(transform.position, player.position) <= 5f)
        {
            agent.SetDestination(player.position); // Устанавливаем целью позицию игрока
        }
        else
        {
            changeDirectionTimer -= Time.deltaTime; // Уменьшаем таймер смены направления

            // Если таймер смены направления истек
            if (changeDirectionTimer <= 0f)
            {
                ChangeDirection(); // Меняем направление движения
            }

            agent.SetDestination(transform.position + randomDirection); // Устанавливаем целью случайное направление
        }
    }

    // Метод для смены направления движения
    void ChangeDirection()
    {
        // Устанавливаем случайное направление в пределах от -1 до 1 по осям X и Z
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        // Устанавливаем новый таймер смены направления в пределах от minChange до maxChange
        changeDirectionTimer = Random.Range(minChange, maxChange);
    }

    // Метод для обработки столкновений
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle collision");    
            StartCoroutine(HandleObstacleCollision());
        }
    }

    // Корутина для обработки столкновения с препятствием
    IEnumerator HandleObstacleCollision()
    {
        agent.speed = 0; // Останавливаем движение
        gameObject.GetComponent<Renderer>().material.color = Color.black; // Меняем цвет 
        // Ждем 5 секунд
        yield return new WaitForSeconds(10);

        gameObject.GetComponent<Renderer>().material.color = Color.red; // Возвращаем цвет
        agent.speed = 3; // Возобновляем движение
    }
}
