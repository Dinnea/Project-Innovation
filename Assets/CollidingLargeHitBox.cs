using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class CollidingLargeHitBox : MonoBehaviour
{

    bool isSafe;

    public UnityEvent OnHitEnemy;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("u a ded bih");
            OnHitEnemy?.Invoke();
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
