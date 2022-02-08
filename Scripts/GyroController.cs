using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    public GameObject cube;
    public float speed;

    private Gyroscope gyroScope;
    private Rigidbody rb;
    bool isEnabled;

    void Start()
    {
        rb = cube.GetComponent<Rigidbody>();

        if (SystemInfo.supportsGyroscope)
        {
            Debug.Log("Gyro is available");
            gyroScope = Input.gyro;
            gyroScope.enabled = true;
            isEnabled = true;
        }
        else
        {
            isEnabled = false;
            Debug.Log("Gyro is not available");
        }
    }

    void Update()
    {
        //MoveCube();
        if (isEnabled) RotateCube();
    }

    void MoveCube()
    {
        Vector3 rawGyroRotation = gyroScope.attitude.eulerAngles;
        Vector3 gyroRotation = new Vector3(-rawGyroRotation.x, rawGyroRotation.z, rawGyroRotation.y);

        //float clampedZ = Mathf.Clamp(gyroRotation.z, -1, 1);
        //Debug.Log("clamped rotation around z: " + clampedZ);

        float zRotation = gyroRotation.z * speed;

        Debug.Log("gyroRotation.z: " + gyroRotation.z);
        //Debug.Log("zRotation: " + zRotation);

        //rb.AddForce(zRotation * speed, 0, 0);
    }

    void RotateCube()
    {
        Debug.Log("Orientation: " + gyroScope.attitude.eulerAngles);
        Vector3 gyroRotation = gyroScope.attitude.eulerAngles;

        cube.transform.rotation = Quaternion.Euler(-gyroRotation.x, gyroRotation.z, gyroRotation.y);
    }
}
