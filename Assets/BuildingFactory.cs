using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : MonoBehaviour, IInfiniteFactory
{
    public string path { get { return "Prefabs/Building"; } }
    private Wave currentWave;
    GameObject building;

    private void Start()
    {
        building = (GameObject)Resources.Load(path);
    }

    public void Spawn()
    {
        currentWave = WaveManager.GetCurrentWave();
        float distance;
   
        if (BuildingSpawner.GetLastPlatformIsCar())
        {
            distance = currentWave.CarBuildingDistance;
            BuildingSpawner.SetLastPlatformIsCar(false);
        }
        else if (BuildingSpawner.GetLastPlatformIsDrone())
        {
            distance = currentWave.droneDistance;
            BuildingSpawner.SetLastPlatformIsDrone(false);
        }
        else distance = Random.Range(currentWave.minDistance, currentWave.maxDistance);
        float offset = Random.Range(currentWave.minOffset, currentWave.maxOffset);

        Vector3 pos = new Vector3(offset, BuildingSpawner.GetCurrentObject().position.y + distance, 0);
        var b = Instantiate(building, pos, Quaternion.identity);
        BuildingSpawner.SetCurrentObject( b.transform);
    }
}
