using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    bool isSafe; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("u a ded bih");
        }//bug.Log(other.gameObject.name);

        else if (other.CompareTag("Safe"))
        {
            isSafe = true;
            Debug.Log("entered building");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Safe"))
        {
            isSafe = false;
            Debug.Log("left building");
        }
    }
}
