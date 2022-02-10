using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public GameObject Background;
    public Transform cam;

    public float BackgroundHeight;

    private Vector3 spawnPosition;
    private float currentBackgroundY = 1;

    private GameObject currentBackground;
    private GameObject previousBackground;

    private void Update()
    {
        if (NewBackgroundNeeded())
        {
            spawnPosition.y =  currentBackgroundY + BackgroundHeight;

            if (previousBackground != null) Destroy(previousBackground);

            previousBackground = currentBackground;
            currentBackground = Instantiate(Background, spawnPosition, Quaternion.identity);
            currentBackgroundY = spawnPosition.y;
        }
    }

    bool NewBackgroundNeeded()
    {
        if (cam.position.y > currentBackgroundY)
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
