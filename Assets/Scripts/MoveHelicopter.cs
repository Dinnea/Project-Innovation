using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelicopter : MonoBehaviour
{
    public GameObject cam;
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

        //HelicopterDoesntLeaveScreen();


        transform.Translate(new Vector3(0, 1, 0) * speed);
    }

    void HelicopterDoesntLeaveScreen()
    {
        if (hasHelicopterArrived)
        {
            transform.Translate(new Vector3(0, 1, 0) * speed);
            StayInScreen();
        }
        else
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * 5);

            if (transform.position.y > cam.transform.position.y + offsetY)
            {
                hasHelicopterArrived = true;
            }
        }
    }

    void StayInScreen()
    {
        if (transform.position.y < cam.transform.position.y + offsetY)
        {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y + offsetY, transform.position.z);
        }
    }
}
