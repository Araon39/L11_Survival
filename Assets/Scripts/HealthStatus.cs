using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatus : MonoBehaviour
{
    public Slider sliderHP;
    private float HPValue = 0.01f;

    public Slider sliderFood;
    private float FoodValue = 0.02f;

    public Slider sliderWater;
    private float waterValue = 0.03f;

    public float HPRecoveryAmount = 0.2f;
    public float FoodRecoveryAmount = 0.3f;
    public float WaterRecoveryAmount = 0.4f;

    void Update()
    {
        ChangeHP();
        ChangeFood();
        ChangeWater();
    }

    void ChangeHP() { sliderHP.value -= HPValue * Time.deltaTime; }
    void ChangeFood() { sliderFood.value -= FoodValue * Time.deltaTime; }
    void ChangeWater() { sliderWater.value -= waterValue * Time.deltaTime; }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HP"))
        {
            sliderHP.value += HPRecoveryAmount;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Food"))
        {
            sliderFood.value += FoodRecoveryAmount;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Water"))
        {
            sliderWater.value += WaterRecoveryAmount;
            Destroy(other.gameObject);
        }
    }
}
