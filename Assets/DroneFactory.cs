using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneFactory : MonoBehaviour, IInfiniteFactory
{
    public string path { get { return "Prefabs/Drone"; } }
    GameObject drone;
    private Wave currentWave;

    private void Start()
    {
        drone = (GameObject)Resources.Load(path);
    }

    public void Spawn()
    {
        currentWave = WaveManager.GetCurrentWave();
        float distance = currentWave.droneDistance;

        Vector3 pos = new Vector3(Random.Range(-4.0f, 4.0f), BuildingSpawner.GetCurrentObject().position.y + distance, 0);
        var d = Instantiate(drone, pos, Quaternion.identity);

        BuildingSpawner.SetCurrentObject(d.transform);
        BuildingSpawner.SetLastPlatformIsDrone(true);
    }

}
