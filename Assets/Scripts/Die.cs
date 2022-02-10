using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Die : MonoBehaviour
{
    Bounce bounce;
    Colliding colliding;
    [SerializeField]Canvas ui;

    private void Awake()
    {
        bounce = GetComponent<Bounce>();
        colliding = GetComponent<Colliding>();
        colliding.SetIsSafe(true);

    }

    private void Update()
    {
        if (!colliding.GetIsSafe() && bounce.GetIsGrounded())
        {
            //Debug.Log("u fell down lmao");
            ExecuteDie();
        }
    }

    public void ExecuteDie()
    {
       
        ui.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
