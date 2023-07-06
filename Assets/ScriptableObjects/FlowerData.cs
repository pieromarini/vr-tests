using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu]
public class FlowerData : ScriptableObject
{
    public string flowerName;
    public float water;
    public float fertilizer;
    public long timeToWaterTicks;
    public long timeToFertilizerTicks;
}