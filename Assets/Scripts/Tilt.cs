using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    public float angle;
    public float almostZero;
    public float rotationSpeed;

    private TwoDGyroController gyroScript;
    private Quaternion tiltedRotationLeft;
    private Quaternion tiltedRotationRight;

    private void Start()
    {
        gyroScript = GetComponent<TwoDGyroController>();
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
