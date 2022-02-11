using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Colliding : MonoBehaviour
{
    bool isSafe;

    public UnityEvent OnHitEnemy;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("u a ded bih");
            OnHitEnemy?.Invoke();
        }//bug.Log(other.gameObject.name);

        else if (other.CompareTag("Safe"))
        {
            isSafe = true;
            //Debug.Log("entered building");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = false;
            //Debug.Log("left building");
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
