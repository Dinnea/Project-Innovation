using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [Header("Objects needed")]
    public GameObject BuildingPrefab;
    public GameObject CarPrefab;
    public GameObject DronePrefab;
    public GameObject FlyingMoneyPrefab;
    public GameObject Background;
    public Transform Camera;
    public Transform currentPlatform;
    public Points points;

    [Header(" ")]
    public float BackgroundHeight;
    public float CarBuildingDistance;

    [Header("Waves")]
    public Wave[] waves;

    public Wave currentWave;

    private Vector3 spawnPosition;
    private float currentBackgroundY = 0;

    private int currentWaveNumber;

    private GameObject currentBackground;
    private GameObject previousBackground;

    private bool lastPlatformIsCar;
    private bool lastPlatformIsDrone;

    private Transform previousPlatform;

    private List<Transform> platforms = new List<Transform>();

    private void Start()
    {
        currentWaveNumber = 0;
        currentWave = waves[currentWaveNumber];
    }

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

            if (currentWave.carChance > chance)
            {
                SpawnCar();
            }
            else if (currentWave.droneChance > chance)
            {
                SpawnDrone();
            }
            else if (currentWave.moneyChance > chance)
            {
                SpawnFlyingMoney();
            }
        }

        DeletePlatforms();

        if (currentWave.NextWaveAtPoints < points.GetPoints())
        {
            StartNextWave();
        }
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
            distance = currentWave.droneDistance;
            lastPlatformIsDrone = false;
        }
        else distance = Random.Range(currentWave.minDistance, currentWave.maxDistance);

        float offset = Random.Range(currentWave.minOffset, currentWave.maxOffset);

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(offset, previousPlatform.position.y + distance, 0);
        var b = Instantiate(BuildingPrefab, pos, Quaternion.identity);
        currentPlatform = b.transform;
        platforms.Add(b.transform);
    }

    private void SpawnCar()
    {
        float distance = Random.Range(currentWave.minDistance, currentWave.maxDistance);

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(0, previousPlatform.position.y + distance, 0);
        var b = Instantiate(CarPrefab, pos, Quaternion.identity);
        currentPlatform = b.transform;
        platforms.Add(b.transform);

        lastPlatformIsCar = true;
    }

    private void SpawnDrone()
    {
        float distance = currentWave.droneDistance;

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(Random.Range(-4.0f, 4.0f), previousPlatform.position.y + distance, 0);
        var d = Instantiate(DronePrefab, pos, Quaternion.identity);
        currentPlatform = d.transform;
        platforms.Add(d.transform);

        lastPlatformIsDrone = true;
    }

    private void SpawnFlyingMoney()
    {
        float distance = currentWave.moneyDistance;

        previousPlatform = currentPlatform;

        Vector3 pos = new Vector3(currentPlatform.position.x, previousPlatform.position.y + distance, 0);
        var d = Instantiate(FlyingMoneyPrefab, pos, Quaternion.identity);
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

    public void StartNextWave()
    {
        if (currentWaveNumber + 1 < waves.Length)
        {
            currentWaveNumber++;
            currentWave = waves[currentWaveNumber];
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
