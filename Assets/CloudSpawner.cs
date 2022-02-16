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
    public UnityEvent ThereAreClouds;
    public UnityEvent NoClouds;
    [Space]
    [SerializeField] float searchCountdown = 1f;
    float search;
    bool areClouds = false;


    // Start is called before the first frame update
    void Start()
    {
        search = searchCountdown;//SpawnManyClouds(spawnNtimes);
    }

    // Update is called once per frame
    void Update()
    {
        SearchForClouds();
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

    void SearchForClouds()
    {
        search -= Time.deltaTime;
        if(search <= 0)
        {
            clouds = GameObject.FindGameObjectsWithTag("Cloud");
            if (clouds.Length == 0)
            {
                if (areClouds)
                {
                    Debug.Log("no clouds");
                    NoClouds?.Invoke();
                    areClouds = false;
                }
               
            }
            else if(!areClouds)
            {
                Debug.Log("yes clouds");
                areClouds = true;
                ThereAreClouds?.Invoke();
            }
            search = searchCountdown;
        }
        
    }
}
