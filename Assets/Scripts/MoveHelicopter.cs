using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    public GameObject camera;
    public float speed;
    public float offsetY;

    public float countDown;

    private bool hasHelicopterArrived;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - countDown < startTime)
        {
            return;
        }

        if (hasHelicopterArrived)
        {
            StayInScreen();
        }
        else
        {
            if (transform.position.y > camera.transform.position.y + offsetY)
            {
                hasHelicopterArrived = true;
            }
        }
        
        transform.Translate(new Vector3(0, 1, 0) * speed);
    }

    void StayInScreen()
    {
        if (transform.position.y < camera.transform.position.y + offsetY)
        {
            transform.position = new Vector3(transform.position.x, camera.transform.position.y + offsetY, transform.position.z);
        }
    }
}