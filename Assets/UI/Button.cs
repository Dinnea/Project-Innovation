using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("UISound");
    }
}
