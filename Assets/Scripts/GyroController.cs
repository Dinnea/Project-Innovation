using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    public GameObject cube;
    public float speed;

    private Gyroscope gyroScope;

    public bool MoveXCubeBool;
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
        if (MoveXCubeBool) MoveXCube();
        if (MoveZCubeBool) MoveZCube();
        if (RotateCubeBool) RotateCube();
    }

    void MoveXCube()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Vector3 gyroRotation = new Vector3(-rawGyroRotation.x, rawGyroRotation.z, rawGyroRotation.y);

        if (gyroRotation.z < 90)
        {
            Debug.Log("positive");
            cube.transform.Translate(gyroRotation.z * speed, 0, 0, Space.World);
        }
        else if (gyroRotation.z >= 270)
        {
            Debug.Log("negative");
            float z = 90 - (gyroRotation.z - 270);
            cube.transform.Translate(z * -speed, 0, 0, Space.World);
        }
    }

    void MoveZCube()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Vector3 gyroRotation = new Vector3(-rawGyroRotation.x, rawGyroRotation.z, rawGyroRotation.y);

        Debug.Log("gyroRotation.x: " + gyroRotation.x);

        if (gyroRotation.x > -90)
        {
            Debug.Log("positive");
            cube.transform.Translate(0, 0, gyroRotation.x * speed, Space.World);
        }
        else if (gyroRotation.x < -270)
        {
            Debug.Log("negative");
            float z = 90 + (gyroRotation.x + 270);
            cube.transform.Translate(0, 0, z * speed, Space.World);
        }
    }

    void RotateCube()
    {
        Vector3 gyroRotation = gyroScope.attitude.eulerAngles;

        cube.transform.rotation = Quaternion.Euler(-gyroRotation.x, gyroRotation.z, -gyroRotation.y);
    }
}
