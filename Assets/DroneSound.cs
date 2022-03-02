using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSound : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("DroneSound");
    }

    private void OnDestroy()
    {
        FindObjectOfType<AudioManager>().Stop("DroneSound");
    }
}
