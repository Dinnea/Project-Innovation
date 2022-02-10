using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool isGrounded;
    public void SetGrounded()
    {
        isGrounded = !isGrounded;
    }

    public void SetNotGrounded()
    {
        isGrounded = false;
    }
}
