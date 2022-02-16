using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] float upperX, lowerX, upperY, lowerY, offsetY;
    [SerializeField]int spawnNtimes = 100;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnManyClouds(spawnNtimes);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnCloud()
    {
        Vector3 position = new Vector3(Random.Range(lowerX, upperX), this.transform.position.y+ Random.Range(lowerY, upperY)+offsetY);
        Instantiate(cloud, position, Quaternion.identity);
    }

    public void SpawnManyClouds(int number)
    {
        for (int i = 0; i < number; i++) SpawnCloud();
    }
}
