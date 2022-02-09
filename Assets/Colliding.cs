using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("u a ded bih");
        }//bug.Log(other.gameObject.name);

        else if (other.CompareTag("Safe"))
        {
            Debug.Log("safe ig");
        }
    }
}
