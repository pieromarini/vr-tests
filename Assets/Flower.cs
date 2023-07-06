using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public FlowerData data;

    void Start()
    {
        
    }

    void Update()
    {
        
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
}
