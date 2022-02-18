using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [Header("Objects needed")]
    public GameObject BuildingPrefab;
    public GameObject CarPrefab;
    public GameObject DronePrefab;
    public GameObject Background;
    public Transform Camera;
    public Transform currentPlatform;

    [Header(" ")]
    public float BackgroundHeight;
    public float CarBuildingDistance;

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

    private Vector3 spawnPosition;
    private float currentBackgroundY = 0;

    private GameObject currentBackground;
    private GameObject previousBackground;

    private bool lastPlatformIsCar;
    private bool lastPlatformIsDrone;

    private Transform previousPlatform;

    private List<Transform> platforms = new List<Transform>();

    private void Update()
    {
        if (NewBackgroundNeeded())
        {
            SpawnBackground();
        }

        if (NewPlatformNeeded())
        {
            SpawnBuilding();

            float chance = Random.Range(0.0f, 1.0f);

            if (carChance > chance)
            {
                SpawnCar();
            }
            else if (droneChance > chance)
            {
                SpawnDrone();
            }
        }

        DeletePlatforms();
    }

    private void SpawnBackground()
    {
        spawnPosition.y = currentBackgroundY + BackgroundHeight;

        if (previousBackground != null) Destroy(previousBackground);

        previousBackground = currentBackground;
        currentBackground = Instantiate(Background, spawnPosition, Quaternion.identity);
        currentBackgroundY = spawnPosition.y;
    }

    private void SpawnBuilding()
    {
        float distance;

        if (lastPlatformIsCar)
        {
            //building after car should be close to car
            distance = CarBuildingDistance;
            lastPlatformIsCar = false;
        }
        else if (lastPlatformIsDrone)
        {
            distance = droneDistance;
            lastPlatformIsDrone = false;
        }
        else distance = Random.Range(minDistance, maxDistance);

        float offset = Random.Range(minOffset, maxOffset);

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(offset, previousPlatform.position.y + distance, 0);
        var b = Instantiate(BuildingPrefab, pos, Quaternion.identity);
        currentPlatform = b.transform;
        platforms.Add(b.transform);
    }

    private void SpawnCar()
    {
        float distance = Random.Range(minDistance, maxDistance);

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(0, previousPlatform.position.y + distance, 0);
        var b = Instantiate(CarPrefab, pos, Quaternion.identity);
        currentPlatform = b.transform;
        platforms.Add(b.transform);

        lastPlatformIsCar = true;
    }

    private void SpawnDrone()
    {
        float distance = droneDistance;

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(Random.Range(-4.0f, 4.0f), previousPlatform.position.y + distance, 0);
        var d = Instantiate(DronePrefab, pos, Quaternion.identity);
        currentPlatform = d.transform;
        platforms.Add(d.transform);

        lastPlatformIsDrone = true;
    }

    private void DeletePlatforms()
    {
        foreach (Transform p in platforms)
        {
            if (p != null)
            {
                if (p.position.y + 20 < Camera.position.y)
                {
                    Destroy(p.gameObject);
                }
            }

        }
    }

    bool NewPlatformNeeded()
    {
        if (Camera.position.y + 12 > currentPlatform.position.y)
        {
            return true;
        }

        return false;
    }

    bool NewBackgroundNeeded()
    {
        if (Camera.position.y > currentBackgroundY)
        {
            return true;
        }

        return false;
    }
}
