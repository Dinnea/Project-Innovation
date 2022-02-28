using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCtrl : MonoBehaviour
{
    public Animator pauseAnimator;

    private void Start()
    {
        pauseAnimator.Play("ButtonSlider");
    }

    public void PlaySlideIn()
    {
        pauseAnimator.SetBool("SlideIn", true);
    }

    public void PlaySlideOut()
    {
        pauseAnimator.SetBool("SlideIn", false);
    }
}
