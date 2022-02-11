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
}
