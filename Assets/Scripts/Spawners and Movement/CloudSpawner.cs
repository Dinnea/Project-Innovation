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
    [SerializeField] float cloudsInterval;
    float search;
    bool areClouds = false;
    ICloudFactory cloudFactory;

    bool isAtCloudSpawningPoint = false;
    bool canCheck = false;

    Points points;
    Colliding colliding;


    void Start()
    {
        search = searchCountdown;
        cloudFactory = GetComponent<ICloudFactory>();
        points = GetComponentInParent<Points>();
        colliding = GetComponentInParent<Colliding>();

        Debug.Log("canSpawnNewClouds: " + canCheck);
    }

    void Update()
    {
        SearchForClouds();

        if (points.GetPoints()%cloudsInterval == 0 && points.GetPoints() != 0 && canCheck)
        {
            isAtCloudSpawningPoint = true;
        }

        if (isAtCloudSpawningPoint && colliding.GetIsOnBuilding())
        {
            Debug.Log("SPAWNING CLOUDS");
            SpawnManyClouds(50);
            isAtCloudSpawningPoint = false;
            canCheck = false;
        }
    }

    public void SpawnManyClouds(int number)
    {
        for (int i = 0; i < number; i++) cloudFactory.Spawn();
    }

    private void SearchForClouds()
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

    public void SetCanCheck(bool value)
    {
        Debug.Log(" set canSpawnNewClouds: " + value);
        canCheck = value;
    }
}
