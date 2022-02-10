using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGyroIW : MonoBehaviour
{
    [Header("Adjust")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    private void Start()
    {
        GyroManagerIW.Instance.EnableGyro();
    }
    private void Update()
    {
        transform.localRotation = GyroManagerIW.Instance.GetGyroRotation() * baseRotation;
    }
}
