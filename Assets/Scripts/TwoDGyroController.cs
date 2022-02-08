using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDGyroController : MonoBehaviour
{
    public GameObject character;
    public float speed;

    private Gyroscope gyroScope;

    public bool EnableMoveY;
    public bool MoveZCubeBool;
    public bool RotateCubeBool;

    bool isEnabled;

    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("Gyro is available");
            gyroScope = Input.gyro;
            gyroScope.enabled = true;
            isEnabled = true;
        }
        else
        {
            Debug.Log("Gyro is not available");
            isEnabled = false;
        }
    }

    void Update()
    {
        if (!isEnabled) return;
        if (EnableMoveY) MoveY();
    }

    //TO DO:
    // add moveX
    // set angle at which character doesn't move

    void MoveY()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Vector3 gyroRotation = new Vector3(-rawGyroRotation.x, rawGyroRotation.x, rawGyroRotation.x);

        //Debug.Log("rotation: " + gyroRotation.x);

        if (gyroRotation.x > -90)
        {
            Debug.Log("positive");
            character.transform.Translate(0, gyroRotation.x * speed, 0, Space.World);
        }
        else if (gyroRotation.x < -270)
        {
            Debug.Log("negative");
            float z = 90 + (gyroRotation.x + 270);
            character.transform.Translate(0, z * speed, 0, Space.World);
        }
    }
}
