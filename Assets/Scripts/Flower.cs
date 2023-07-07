using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public FlowerData data;

    // Timer management
    TimeSpan waterTS;
    TimeSpan fertilizeTS;
    private bool timerOnWater = false;
    private bool timerOnFertilize = false;

    void Start()
    {
        waterTS = getTimeToWater();
        fertilizeTS = getTimeToFertilize();

        timerOnWater = true;
        timerOnFertilize = true;
    }

    void Update()
    {
        if (timerOnWater)
        {
            if (waterTS.TotalMilliseconds > 0)
            {
                waterTS -= TimeSpan.FromSeconds(Time.deltaTime);
            }
            else
            {
                timerOnWater = false;
            }
        }

        if (timerOnFertilize)
        {
            if (fertilizeTS.TotalMilliseconds > 0)
            {
                fertilizeTS -= TimeSpan.FromSeconds(Time.deltaTime);
            }
            else
            {
                timerOnFertilize = false;
            }
        }
    }

    public string getFlowerName()
    {
        return data.name;
    }

    public float getWaterNeeds()
    {
        return data.water;
    }

    public float getFertilizerNeeds()
    {
        return data.fertilizer;
    }

    public TimeSpan remaningTimeWater()
    {
        return waterTS;
    }

    public TimeSpan remaningTimeFertilizer()
    {
        return fertilizeTS;
    }

    TimeSpan getTimeToWater()
    {
        return TimeSpan.FromMinutes(data.timeToWaterMinutes);
    }

    TimeSpan getTimeToFertilize()
    {
        return TimeSpan.FromMinutes(data.timeToFertilizerMinutes);
    }
}
