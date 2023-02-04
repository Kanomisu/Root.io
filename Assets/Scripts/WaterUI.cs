using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public Slider waterMeter;
    float maxWater = 10;
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
        currentWater -= Time.deltaTime;

        if (currentWater > 0)
        {
            waterMeter.value = currentWater;
        }
        else
        {
            //Debug.Log("Dehydrated");
        }
    }

    //For when you collide with a pocket of water
    public void WaterAddition(int amount)
    {
        if (currentWater + amount <= 10)
        {
            currentWater += amount;
            waterMeter.value = currentWater;
        }
        else
        {
            Debug.Log("Tree died");
        }
    }

}