using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public Slider waterMeter;
    float maxWater = 1000;
    float minWater = 0;
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
        currentWater -= Time.deltaTime * 12;

        if (currentWater > 0)
        {
            waterMeter.value = currentWater;

            if (CameraScript.instance.endGame == true)
            {
                waterMeter.value = minWater; 
            }
        }
    }

    //For when you collide with a pocket of water
    public void WaterAddition(int amount)
    {
        if (amount + currentWater > maxWater)
        {
            currentWater = maxWater;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            currentWater += amount;
            waterMeter.value = currentWater;
            GetComponent<AudioSource>().Play();
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