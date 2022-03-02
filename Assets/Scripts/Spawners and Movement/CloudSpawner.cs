using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    GameObject[] clouds;
    public UnityEvent ThereAreClouds;
    public UnityEvent NoClouds;
    [Space]
    [SerializeField] float searchCountdown = 1f;
    float search;
    bool areClouds = false;
    ICloudFactory cloudFactory;


    void Start()
    {
        search = searchCountdown;
        cloudFactory = GetComponent<ICloudFactory>();
    }

    void Update()
    {
        SearchForClouds();
    }

    public void SpawnManyClouds(int number)
    {
        for (int i = 0; i < number; i++) cloudFactory.Spawn();
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
