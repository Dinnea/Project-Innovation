using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Die : MonoBehaviour
{
    Bounce bounce;
    Colliding colliding;
    [SerializeField]AudioSource death;
    [SerializeField]GameObject ui;
    public UnityEvent onFall;
    public UnityEvent onDeath;


    private void Awake()
    {
        bounce = GetComponent<Bounce>();
        colliding = GetComponentInParent<Colliding>();
        colliding.SetIsSafe(true);
    }

    private void Update()
    {
        if (!colliding.GetIsSafe() && bounce.GetIsGrounded())
        {
            onFall?.Invoke();//Debug.Log("u fell down lmao");
            //ExecuteDie();
        }
    }

    public void ExecuteDie()
    {       
        ui.SetActive(true);
        Destroy(gameObject);
        onDeath?.Invoke();
    }

    public void PlayDeathEffect()
    {
        death.Play();
    }
}
