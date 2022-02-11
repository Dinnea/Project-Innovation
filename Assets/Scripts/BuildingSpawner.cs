using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public GameObject Background;
    public Transform Camera;


    public float BackgroundHeight;

    private Vector3 spawnPosition;
    private float currentBackgroundY = 1;

    private GameObject currentBackground;
    private GameObject previousBackground;

    private GameObject currentBuilding;
    public float buildingOffset;
    public GameObject previousBuilding;

    private void Update()
    {
        if (NewBackgroundNeeded())
        {
            spawnPosition.y =  currentBackgroundY + BackgroundHeight;

            if (previousBackground != null) Destroy(previousBackground);

            previousBackground = currentBackground;
            currentBackground = Instantiate(Background, spawnPosition, Quaternion.identity);
            currentBackgroundY = spawnPosition.y;

            /*
            Instantiate(BuildingPrefab, new Vector3(spawnPosition.x - 2, spawnPosition.y - 7.5f, 0), Quaternion.identity);
            Instantiate(BuildingPrefab, new Vector3(spawnPosition.x + 2, spawnPosition.y, 0), Quaternion.identity);
            Instantiate(BuildingPrefab, new Vector3(spawnPosition.x, spawnPosition.y + 7.5f, 0), Quaternion.identity);
            */
        }
    }

    bool NewBackgroundNeeded()
    {
        if (Camera.position.y > currentBackgroundY)
        {
            return true;
        }

        return false;
    }
    
    /*
    void SpawnBuilding()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnPosition = new Vector3(Random.Range(MinXPos, MaxXPos), cam.position.y, 0);
            Instantiate(BuildingPrefab, spawnPosition, Quaternion.identity);
        }
    }
    */
}
