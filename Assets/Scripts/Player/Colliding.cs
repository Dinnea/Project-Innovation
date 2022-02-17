using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Colliding : MonoBehaviour
{
    bool isSafe;
    public UnityEvent OnEnterBuilding;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            OnEnterBuilding?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = false;
        }
    }

    public bool GetIsSafe()
    {
        return isSafe;
    }

    public void SetIsSafe(bool value)
    {
        isSafe = value;
    }
}
