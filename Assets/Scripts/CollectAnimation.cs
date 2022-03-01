using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAnimation : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnCollected()
    {
        animator.SetBool("GotCollected", true);
    }

    public void DestroyCollectible()
    {
        Destroy(gameObject);
    }
}
