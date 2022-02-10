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
        //ui.gameObject.SetActive(false);

        colliding.OnHitEnemy += hitEnemy;
    }

    private void Update()
    {
        if (!colliding.GetIsSafe() && bounce.GetIsGrounded())
        {
            Debug.Log("u fell down lmao");
            die();
        }
    }

    void hitEnemy(object sender, EventArgs e)
    {
        die();
    }
    void die()
    {
       
        ui.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
