using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject countdown;
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        countdown.SetActive(true);
    }
    
    public void ExitGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

}
