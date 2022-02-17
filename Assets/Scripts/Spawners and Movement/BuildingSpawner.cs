using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [Header("Objects needed")]
    public GameObject BuildingPrefab;
    public GameObject Background;
    public Transform Camera;
    public Transform currentBuilding;

    [Header(" ")]
    public float BackgroundHeight;

    [Header("Y distance between buildings")]
    public float minDistance;
    public float maxDistance;

    [Header("X offset")]
    public float minOffset;
    public float maxOffset;

    private Vector3 spawnPosition;
    private float currentBackgroundY = 1;

    private GameObject currentBackground;
    private GameObject previousBackground;

    
    private Transform previousBuilding;

    private List<Transform> buildings = new List<Transform>();

    private void Update()
    {
        if (NewBackgroundNeeded())
        {
            SpawnBackground();
        }

        if (NewBuildingNeeded())
        {
            SpawnBuilding();
        }

        DeleteBuildings();
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
        for (int i = 0; i < 1; i++)
        {
            float distance = Random.Range(minDistance, maxDistance);
            float offset = Random.Range(minOffset, maxOffset);

            previousBuilding = currentBuilding;

            Vector3 pos = new Vector3(offset, previousBuilding.position.y + distance, 0);
            var b = Instantiate(BuildingPrefab, pos, Quaternion.identity);
            currentBuilding = b.transform;
            buildings.Add(b.transform);
        }
    }

    private void DeleteBuildings()
    {
        foreach (Transform b in buildings)
        {
            if (b != null)
            {
                if (b.position.y + 20 < Camera.position.y)
                {
                    Destroy(b.gameObject);
                }
            }
            
        }
    }

    bool NewBuildingNeeded()
    {
        if (Camera.position.y + 12 > currentBuilding.position.y)
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
