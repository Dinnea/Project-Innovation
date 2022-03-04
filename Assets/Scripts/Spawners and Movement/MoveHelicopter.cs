using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    public GameObject cam;
    public float SlowSpeed;
    public float FastSpeed;
    public float offsetY;

    public float countDown;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        //Debug.Log(hasHelicopterArrived());
        if (Time.time - countDown < startTime)
        {
            return;
        }

        if (hasHelicopterArrived())
        {
            if (CloudSpawner.areClouds)
            {
                transform.Translate(new Vector3(0, 1, 0) * 0.8f * Time.deltaTime);
            }
            else transform.Translate(new Vector3(0, 1, 0) * SlowSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(0, 1, 0) * FastSpeed * Time.deltaTime);
        }
        
    }

    private bool hasHelicopterArrived()
    {
        if (transform.position.y > cam.transform.position.y + offsetY)
        {
            return true;
        }

        return false;
    }

    public void ChangeSpeed(float speed)
    {
        SlowSpeed = speed;
    }
}
