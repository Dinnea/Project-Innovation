using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Bounce bounce;
    Colliding colliding;

    private void Start()
    {
        bounce = GetComponent<Bounce>();
        colliding = GetComponent<Colliding>();
    }

    private void Update()
    {
        if (!colliding.GetIsSafe() && bounce.GetIsGrounded())
        {
            Debug.Log("u fell down u stoopid bih");
        }
    }
}
