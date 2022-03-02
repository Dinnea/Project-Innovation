using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float NextWaveAtPoints;

    [Header("Y distance between buildings")]
    public float minDistance;
    public float maxDistance;

    [Header("X offset buildings")]
    public float minOffset;
    public float maxOffset;

    [Header("Drone and money distance")]
    public float droneDistance;
    public float moneyDistance;

    [Header("Spawn chance")]
    [Range(0.0f, 1.0f)]
    public float carChance;
    [Range(0.0f, 1.0f)]
    public float droneChance;
    [Range(0.0f, 1.0f)]
    public float moneyChance;

    public float CarBuildingDistance = 4;
}
