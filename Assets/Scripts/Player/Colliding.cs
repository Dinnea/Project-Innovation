using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Colliding : MonoBehaviour
{
    bool isSafe;
    public UnityEvent OnEnterBuilding;
    public UnityEvent OnHitEnemy;
    public UnityEvent OnHitCollectible;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            OnEnterBuilding?.Invoke();
        }

        if (other.CompareTag("Collectible"))
        {
            OnHitCollectible?.Invoke();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = true;
        }
        else if(other.CompareTag("Enemy"))
        {
            Debug.Log("u a ded bih");
            OnHitEnemy?.Invoke();
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
