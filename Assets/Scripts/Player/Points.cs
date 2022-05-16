using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Points : MonoBehaviour
{
    public UnityEvent OnPointsAdded;

    [SerializeField]TextMeshProUGUI text;
    [SerializeField]float points = -100;
    //bool haveCloudsSpawned = false;

    private void Update()
    {
        /*
        if(points%1000 == 0 && points!=0)
        {
            if (!haveCloudsSpawned)
            {
                OnPointsGathered?.Invoke();
                haveCloudsSpawned = true;
            }
        }
        else if(haveCloudsSpawned == true)
        {
            haveCloudsSpawned = false;
        }
        */
    }
    public void AddPoints(float pPoints)
    {
        points += pPoints;
        SetPointsText();
        OnPointsAdded?.Invoke();
    }

    public float GetPoints()
    {
        return points;
    }

    void SetPointsText()
    {
        text.text = points.ToString();
    }

    public void SavePoints()
    {
        HighScores.AddHighScore(points);
    }

}
