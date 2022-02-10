using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public float OffsetY;

    private void Update()
    {
        if(Target != null) transform.position = new Vector3(transform.position.x, Target.transform.position.y + OffsetY, transform.position.z);
    }
}
