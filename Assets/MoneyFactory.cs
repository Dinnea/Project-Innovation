using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFactory : MonoBehaviour, IInfiniteFactory
{
    public string path { get { return "Prefabs/FlyingCollectible"; } }
    GameObject money;
    private Wave currentWave;

    private void Start()
    {
        money = (GameObject)Resources.Load(path);
    }

    public void Spawn()
    {
        currentWave = WaveManager.GetCurrentWave();
        float distance = currentWave.moneyDistance;


        Vector3 pos = new Vector3(BuildingSpawner.GetCurrentObject().position.x, BuildingSpawner.GetCurrentObject().position.y + distance, 0);
        var d = Instantiate(money, pos, Quaternion.identity);
        BuildingSpawner.SetCurrentObject( d.transform);
        
        BuildingSpawner.SetLastPlatformIsDrone(true);
    }
}
