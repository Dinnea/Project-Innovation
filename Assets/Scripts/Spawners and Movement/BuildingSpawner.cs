using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [Header("Objects needed")]
    public GameObject BuildingPrefab;
    public GameObject CarPrefab;
    public GameObject Background;
    public Transform Camera;
    public Transform currentPlatform;

    [Header(" ")]
    public float BackgroundHeight;
    public float CarBuildingDistance;

    [Header("Y distance between buildings")]
    public float minDistance;
    public float maxDistance;

    [Header("X offset")]
    public float minOffset;
    public float maxOffset;

    [Header("Buildings between cars")]
    public int minAmount;
    public int maxAmount;

    private Vector3 spawnPosition;
    private float currentBackgroundY = 1;
    
    private int buildingsBetweenCars;
    private int buildingsSpawned;

    private GameObject currentBackground;
    private GameObject previousBackground;


    private Transform previousPlatform;

    private List<Transform> platforms = new List<Transform>();

    private void Start()
    {
        buildingsBetweenCars = Random.Range(minAmount, maxAmount + 1);
    }

    private void Update()
    {
        if (NewBackgroundNeeded())
        {
            SpawnBackground();
        }

        if (NewPlatformNeeded())
        {
            if (buildingsSpawned < buildingsBetweenCars)
            {
                SpawnBuilding();
            }
            else
            {
                SpawnCar();
                buildingsSpawned = 0;
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

        if (buildingsSpawned == 0)
        {
            //building after car should be close to car
            distance = CarBuildingDistance;
        }
        else distance = Random.Range(minDistance, maxDistance);

        float offset = Random.Range(minOffset, maxOffset);

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(offset, previousPlatform.position.y + distance, 0);
        var b = Instantiate(BuildingPrefab, pos, Quaternion.identity);
        currentPlatform = b.transform;
        platforms.Add(b.transform);

        buildingsSpawned++;
    }

    private void SpawnCar()
    {
        float distance = Random.Range(minDistance, maxDistance);

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(0, previousPlatform.position.y + distance, 0);
        var b = Instantiate(CarPrefab, pos, Quaternion.identity);
        currentPlatform = b.transform;
        platforms.Add(b.transform);
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
