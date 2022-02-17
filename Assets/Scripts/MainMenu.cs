using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/new", LoadSceneMode.Single); 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

