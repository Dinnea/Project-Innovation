using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFactory : MonoBehaviour, ICloudFactory
{
    [SerializeField] float upperX, lowerX, upperY, lowerY, offsetY;
    GameObject cloud;

    private void Start()
    {
        cloud = (GameObject)Resources.Load(path);
    }
    public string path 
    { 
        get { return "Prefabs/Cloud"; } 
    }

    public void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(lowerX, upperX), this.transform.position.y + Random.Range(lowerY, upperY) + offsetY);
        GameObject spawned = Instantiate(cloud, position, Quaternion.identity);
        spawned.name = "cloud";
    }
}
