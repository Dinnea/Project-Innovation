using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class Colliding : MonoBehaviour
{
    bool isSafe;
    bool isOnCableCar;
    public bool isOnBuilding = true;
    public UnityEvent OnEnterBuilding;
    public UnityEvent OnHitEnemy;
    public UnityEvent OnHitCollectible;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            OnEnterBuilding?.Invoke();
            isOnBuilding = true;
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
        if (other.CompareTag("Building"))
        {
            isSafe = true;
            isOnBuilding = true;
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
        if (other.CompareTag("Building"))
        {
            isSafe = false;
            isOnBuilding = false;
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

    public bool GetIsOnBuilding()
    {
        return isOnBuilding;
    }

    public void SetIsSafe(bool value)
    {
        isSafe = value;
    }

}
