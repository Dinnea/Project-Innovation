using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    IInfiniteFactory buildingFactory;
    IInfiniteFactory carFactory;
    IInfiniteFactory droneFactory;
    IInfiniteFactory moneyFactory;

    public GameObject CarPrefab;
    public GameObject DronePrefab;
    public GameObject FlyingMoneyPrefab;
    public Transform Camera;
    public Points points;

    [SerializeField] Transform firstBuilding;

    [Header(" ")]

    Wave currentWave;

    static bool lastPlatformIsCar = false;

    public static void SetLastPlatformIsCar(bool value)
    {
        lastPlatformIsCar = value;
    }
    public static bool GetLastPlatformIsCar()
    {
        return lastPlatformIsCar;
    }

    static bool lastPlatformIsDrone = false;
    public static void SetLastPlatformIsDrone(bool value)
    {
        lastPlatformIsDrone = value;
    }
    public static bool GetLastPlatformIsDrone()
    {
        return lastPlatformIsDrone;
    }

    static Transform currentObject;
    public static void SetCurrentObject(Transform newObject)
    {
        currentObject = newObject;
        objects.Add(newObject);
    }
    public static Transform GetCurrentObject()
    {
        return currentObject;
    }

    static List<Transform> objects = new List<Transform>();
    
    private void Start()
    {
        buildingFactory = GetComponent<BuildingFactory>();
        carFactory = GetComponent<CarFactory>();
        droneFactory = GetComponent<DroneFactory>();
        moneyFactory = GetComponent<MoneyFactory>();

        currentWave = WaveManager.GetCurrentWave();
        currentObject = firstBuilding;

        lastPlatformIsCar = false;
        lastPlatformIsDrone = false;
    }

    private void Update()
    {

        if (NewPlatformNeeded())
        {
            buildingFactory.Spawn();

            float chance = Random.Range(0.0f, 1.0f);

            if (currentWave.carChance > chance)
            {
                carFactory.Spawn();
            }
            else if (currentWave.droneChance > chance)
            {
                droneFactory.Spawn();
            }
            else if (currentWave.moneyChance > chance)
            {
                moneyFactory.Spawn();
            }
        }

        DeletePlatforms();

        if (currentWave.NextWaveAtPoints < points.GetPoints())
        {
            
            StartNextWave();
        }
    }


    private void DeletePlatforms()
    {
        foreach (Transform p in objects)
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
        WaveManager.NextWave();
        currentWave = WaveManager.GetCurrentWave();
    }

    bool NewPlatformNeeded()
    {
        if (Camera.position.y + 12 > currentObject.position.y)
        {
            return true;
        }

        return false;
    }
}
