using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public bool isGrounded;
    AudioSource bounce;

    private void Awake()
    {
        bounce = GetComponent<AudioSource>();
    }
    public void SetGrounded()
    {
        isGrounded = !isGrounded;
    }

    public void SetIfGrounded(bool value)
    {
        isGrounded = value;
    }

    public bool GetIsGrounded()
    {
        return isGrounded;
    }

    public void PlayEffect()
    {
        bounce.Play();
    }
}
