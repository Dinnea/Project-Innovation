using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFactory : MonoBehaviour, IInfiniteFactory
{
    public string path { get { return "Prefabs/CableCar"; } }
    GameObject car;
    private Wave currentWave;

    private void Start()
    {
        car = (GameObject)Resources.Load(path);
    }
 
    public void Spawn()
    {
        currentWave = WaveManager.GetCurrentWave();
        float distance = Random.Range(currentWave.minDistance, currentWave.maxDistance);

        Vector3 pos = new Vector3(0, BuildingSpawner.GetCurrentObject().position.y + distance, 0);
        var b = Instantiate(car, pos, Quaternion.identity);
        BuildingSpawner.SetCurrentObject( b.transform);

        BuildingSpawner.SetLastPlatformIsCar( true);
    }
}
