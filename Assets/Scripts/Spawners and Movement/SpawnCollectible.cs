using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectible : MonoBehaviour
{
    public GameObject CollectiblePrefab;

    void Start()
    {
        if (Random.Range(0, 2) ==  0)
        {
            var c = Instantiate(CollectiblePrefab, transform.position, Quaternion.identity);
            c.transform.parent = this.transform;
        }
    }
}
