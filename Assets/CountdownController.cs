using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    [SerializeField] TextMeshProUGUI _countdownDisplay;


    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {
        while (countdownTime >= 0)
        {
            _countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
    }
}
