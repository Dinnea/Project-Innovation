using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    public GameObject CollectiblePrefab;

    void Start()
    {
        int random = Random.Range(0, 6);

        if (random < 2)
        {
            var c = Instantiate(CollectiblePrefab, transform.position, Quaternion.identity);
            c.transform.parent = this.transform;
        }
    }
}
