using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] float upperX, lowerX, upperY, lowerY, offsetY;
    [SerializeField]int spawnNtimes = 100;
    GameObject[] clouds;


    // Start is called before the first frame update
    void Start()
    {
        //SpawnManyClouds(spawnNtimes);
    }

    // Update is called once per frame
    void Update()
    {
        clouds = GameObject.FindGameObjectsWithTag("Cloud");
        if(clouds.Length == 0)
        {
            Debug.Log("no clouds");
        }
        else
        {
            Debug.Log("yes clouds");
        }
    }

    void SpawnCloud()
    {
        Vector3 position = new Vector3(Random.Range(lowerX, upperX), this.transform.position.y+ Random.Range(lowerY, upperY)+offsetY);
        GameObject spawned = Instantiate(cloud, position, Quaternion.identity);
        spawned.name = "cloud";
    }

    public void SpawnManyClouds(int number)
    {
        for (int i = 0; i < number; i++) SpawnCloud();
    }
}
