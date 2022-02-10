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

    public void SetNotGrounded(bool value)
    {
        isGrounded = value;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }
}
