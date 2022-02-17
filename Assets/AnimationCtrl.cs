using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCtrl : MonoBehaviour
{
    public Animator pauseAnimator;

    private bool slideIn = false;

    public void PauseBtnMethod()
    {
        if (slideIn == false)
        {
            slideIn = true;
            pauseAnimator.SetBool("SlideIn",slideIn);
        }
        
        else if (slideIn == true)
        {
            slideIn = false;
            pauseAnimator.SetBool("SlideIn",slideIn);
        }
    }
}
