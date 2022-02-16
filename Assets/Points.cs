using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{

    [SerializeField]TextMeshProUGUI text;
    float points = -100;


    public void AddPoints(float pPoints)
    {
        points += pPoints;
        SetPointsText();
    }

    void SetPointsText()
    {
        text.text = points.ToString();
    }
}
