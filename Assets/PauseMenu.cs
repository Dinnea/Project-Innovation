using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
    
    public void ExitGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

}
