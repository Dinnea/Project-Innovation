using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Colliding : MonoBehaviour
{
    bool isSafe;
    public event EventHandler OnHitEnemy;
    //bool hitEnemy = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("u a ded bih");
            OnHitEnemy?.Invoke(this, EventArgs.Empty);
        }//bug.Log(other.gameObject.name);

        else if (other.CompareTag("Safe"))
        {
            isSafe = true;
            Debug.Log("entered building");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = false;
            Debug.Log("left building");
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
