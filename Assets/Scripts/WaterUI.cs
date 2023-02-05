using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public Slider waterMeter;
    float maxWater = 100;
    float currentWater;
    public static WaterUI instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentWater = maxWater;
        waterMeter.maxValue = maxWater;
        waterMeter.value = maxWater;
    }

    //Deplete the water meter
    void Update()
    {
        currentWater -= Time.deltaTime * 10;

        if (currentWater > 0)
        {
            waterMeter.value = currentWater;
        }
    }

    //For when you collide with a pocket of water
    public void WaterAddition(int amount)
    {
        currentWater += amount;
        waterMeter.value = currentWater;
    }
    public void WaterSubtraction(int amount)
    {
        currentWater -= amount;
        waterMeter.value = currentWater;
    }
    public float GetWaterLevel()
    {
        return currentWater;
    }
}