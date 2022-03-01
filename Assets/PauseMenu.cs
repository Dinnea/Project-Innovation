using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject countdown;
    

    
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    /*public void PlaySlideIn()
    {
        animator.SetBool("SlideIn",true);
    }

    public void PlaySlideOut()
    {
        animator.SetBool("SlideIn",false);
    }*/

    public void Continue()
    {
       pauseMenu.SetActive(false);
        playButton.SetActive(false);
        //pauseButton.SetActive(true);
       
        countdown.SetActive(true);
        

    }
    
    public void ExitGameScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
