using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("Music", volume);
    }

    public float GetMusicVolume()
    {
        float value;
        bool result = mainMixer.GetFloat("Music", out value);

        if (result) return value;
        else return 0;
    }

    public void SetEffectsVolume(float volume)
    {
        mainMixer.SetFloat("Effects", volume);
    }

    public float GetEffectsVolume()
    {
        float value;
        bool result = mainMixer.GetFloat("Effects", out value);

        if (result) return value;
        else return 0;
    }
}

