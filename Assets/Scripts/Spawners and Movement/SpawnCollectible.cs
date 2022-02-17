using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    public GameObject CollectiblePrefab;
    public GameObject DronePrefab;

    void Start()
    {
        int random = Random.Range(0, 5);

        if (random < 3)
        {
            var c = Instantiate(CollectiblePrefab, transform.position, Quaternion.identity);
            c.transform.parent = this.transform;
        }

        if (random == 3)
        {
            var c = Instantiate(DronePrefab, transform.position, Quaternion.identity);
            c.transform.parent = this.transform;
        }
    }
}
