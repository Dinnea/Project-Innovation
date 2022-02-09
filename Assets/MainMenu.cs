using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer musicMixer;

    public AudioMixer effectsMixer;

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("Music", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        effectsMixer.SetFloat("Effects", volume);
    }
}

