using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManagerIW : MonoBehaviour
{
    #region Instance

    private static GyroManagerIW instance;
    public static GyroManagerIW Instance 
    { 
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManagerIW>();
                if (instance != null)
                {
                    instance = new GameObject("Spawbed GyroManager", typeof(GyroManagerIW)).GetComponent<GyroManagerIW>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool isActive;

    public void EnableGyro()
    {
        if (isActive) return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            isActive = gyro.enabled;
        }
        else Debug.Log("not supported");
        
    }

    void setGyroRotation()
    {
        if (isActive)
        {
            rotation = gyro.attitude;
            Debug.Log(rotation);
        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }

    private void Update()
    {
        setGyroRotation();
    }
}
