using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.mGroup;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //Play("MenuTheme");
        
    }
    void OnEnable () {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
        
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
 
        if (sceneName == "2DScene") 
        {
            Stop("MenuTheme");
            Play("IngameTheme");
        }
        
        else if (sceneName == "MainMenu") 
        {
            Stop("IngameTheme");
            Play("MenuTheme");
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found! (check for typos)" );
            return;
        }
            s.source.Play();
    }
    
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found! (check for typos)" );
            return;
        }
      
        s.source.Stop();
    }
}
