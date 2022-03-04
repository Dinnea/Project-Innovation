using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnDeath()
    {
        animator.SetBool("hasDied", true);
    }

    public void OnHitEnemy()
    {
        animator.SetBool("gotHit", true);
    }
}
