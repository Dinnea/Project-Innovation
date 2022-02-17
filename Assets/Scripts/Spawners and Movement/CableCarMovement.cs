using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableCarMovement : MonoBehaviour
{
    public float Speed;
    public float Xpos1;
    public float Xpos2;

    void Update()
    {
        transform.Translate(new Vector3(Speed, 0, 0));

        if (transform.position.x < Xpos1)
        {
            transform.position = new Vector3(Xpos2, transform.position.y, transform.position.z);
        }
    }
}
