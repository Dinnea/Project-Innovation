using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayContinue : MonoBehaviour
{
   public void GameUnpaused()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
