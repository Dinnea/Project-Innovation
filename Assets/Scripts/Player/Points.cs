using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Points : MonoBehaviour
{
    public UnityEvent OnPointsGathered;

    private Colliding colliding;

    [SerializeField]TextMeshProUGUI text;
    [SerializeField]float points = -100;
    bool haveCloudsSpawned = false;

    private void Start()
    {
        colliding = GetComponent<Colliding>();
    }

    private void Update()
    {
        if(points%1000 == 0 && points!=0)
        {
            if (!haveCloudsSpawned && !colliding.GetIsOnCableCar())
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
