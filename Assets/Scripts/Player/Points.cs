using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Points : MonoBehaviour
{
    public UnityEvent OnPointsGathered;

    [SerializeField]TextMeshProUGUI text;
    float points = -100;
    bool haveCloudsSpawned = false;

    private void Update()
    {
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
    }
    public void AddPoints(float pPoints)
    {
        points += pPoints;
        SetPointsText();
    }

    public float GetPoints()
    {
        return points;
    }

    void SetPointsText()
    {
        text.text = points.ToString();
    }

}
