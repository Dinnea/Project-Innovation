using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    //private GameObject playerSprite;
    public TwoDGyroController gyroScript;

    public float angle;
    public float almostZero;
    public float rotationSpeed;

    private Quaternion tiltedRotationLeft;
    private Quaternion tiltedRotationRight;

    private void Start()
    {
        //playerSprite = GetComponentInChildren<GameObject>();

        tiltedRotationLeft = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, -angle));
        tiltedRotationRight = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, angle));
    }

    private void Update()
    {
        if (gyroScript.rotationAroundY > almostZero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, tiltedRotationLeft, Time.deltaTime * rotationSpeed);
        }
        else if (gyroScript.rotationAroundY < -almostZero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, tiltedRotationRight, Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * rotationSpeed);
        }
    }
}
