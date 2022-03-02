using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Colliding : MonoBehaviour
{
    bool isSafe;
    public bool isOnCableCar;
    public UnityEvent OnEnterBuilding;
    public UnityEvent OnHitEnemy;
    public UnityEvent OnHitCollectible;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            OnEnterBuilding?.Invoke();
        }

        if (other.CompareTag("CableCar"))
        {
            OnEnterBuilding?.Invoke();
            isOnCableCar = true;
        }

        if (other.CompareTag("Collectible"))
        {
            OnHitCollectible?.Invoke();
            FindObjectOfType<AudioManager>().Play("Collectible");
            other.GetComponent<CollectAnimation>().OnCollected();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = true;
        }
        else if (other.CompareTag("CableCar"))
        {
            isSafe = true;
            isOnCableCar = true;
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

        if (other.CompareTag("CableCar"))
        {
            isSafe = false;
            isOnCableCar = false;
        }
    }

    public bool GetIsSafe()
    {
        return isSafe;
    }

    public bool GetIsOnCableCar()
    {
        return isOnCableCar;
    }

    public void SetIsSafe(bool value)
    {
        isSafe = value;
    }

}
