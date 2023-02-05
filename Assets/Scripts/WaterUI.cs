using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public Slider waterMeter;
    float maxWater = 1000;
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
        if (amount + currentWater > maxWater)
        {
            currentWater = maxWater;
        }
        else
        {
            currentWater += amount;
            waterMeter.value = currentWater;
        }
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