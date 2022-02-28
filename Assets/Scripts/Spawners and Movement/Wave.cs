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

    [Header("Drone distance")]
    public float droneDistance;

    [Header("Spawn chance")]
    [Range(0.0f, 1.0f)]
    public float carChance;
    [Range(0.0f, 1.0f)]
    public float droneChance;
}
