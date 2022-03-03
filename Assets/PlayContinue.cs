using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayContinue : MonoBehaviour
{
    [SerializeField] GameObject pauseButton;
    private void Awake()
    {
        
    }
    public void StartCountdown()
    {
        Time.timeScale = 0;
    }
    public void GameUnpaused()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
