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

    public float pitch;
    public float yaw;

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

        // in Start(), initialize your x & y angles to match the camera's initial orientation.
        pitch = transform.eulerAngles.x;
        yaw = transform.eulerAngles.y;
    }

    void Update()
    {
        if (!isEnabled) return;
        if (MoveXCubeBool) MoveXCube();
        if (MoveZCubeBool) MoveZCube();
        if (RotateCubeBool) RotateCube();

        moveTest();
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

    void moveTest()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Quaternion gyroRotation = Quaternion.Euler(-gyroScope.attitude.eulerAngles.x, gyroScope.attitude.eulerAngles.z, gyroScope.attitude.eulerAngles.y);

        //new Quaternion(0.5f, 0.5f, -0.5f, 0.5f) * gyroScope.attitude * new Quaternion(1, 0, 0, 0);
        //new Quaternion(0.0f, 0.5f, 0.5f, 0.0f) *

        //new Quaternion(0, 0.5f, 0.5f, 0) * gyroScope.attitude;GyroRotation.z, rawGyroRotation.z);
        //new Quaternion(0.5f, 0.5f, -0.5f, 0.5f)
        //Quaternion.Euler(-rawGyroRotation.x, raw * gyroScope.attitude * new Quaternion(0, 0, 1, 0);

        /*
        Quaternion eliminationOfYZ = Quaternion.Inverse(
            Quaternion.FromToRotation(Quaternion.identity * Vector3.right,
                                      gyroRotation * Vector3.right)
        );
        Quaternion rotationX = eliminationOfYZ * gyroRotation;

        Quaternion eliminationOfXY = Quaternion.Inverse(
            Quaternion.FromToRotation(Quaternion.identity * Vector3.forward,
                                      gyroRotation * Vector3.forward)
            );
        Quaternion rotationZ = eliminationOfXY * gyroRotation;
        */

        //cube.transform.rotation = Quaternion.Euler(rotationX.eulerAngles.x, 0, -rotationZ.eulerAngles.z);

        //Quaternion rotationX = new Quaternion(-Input.gyro.attitude.x, 0, 0, Input.gyro.attitude.w);
        //Quaternion rotationZ = new Quaternion(0, 0, -Input.gyro.attitude.y, Input.gyro.attitude.w);

        //cube.transform.rotation = new Quaternion(-Input.gyro.attitude.x, 0, 0, Input.gyro.attitude.w);

        //Debug.Log("rotationRate: " + gyroScope.rotationRateUnbiased);

        Debug.Log("rotationrate x: " + gyroScope.rotationRateUnbiased.x);

        // In Update, accumulate rotational change in these axes:
        pitch += gyroScope.rotationRateUnbiased.x * Time.deltaTime;
        yaw += gyroScope.rotationRateUnbiased.y * Time.deltaTime;
        // Apply the result all at once:
        cube.transform.eulerAngles = new Vector3(pitch, yaw, 0);

        cube.transform.Translate(new Vector3(yaw * speed, -pitch * speed, 0));


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
