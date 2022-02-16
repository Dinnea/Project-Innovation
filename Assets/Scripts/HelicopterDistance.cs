using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterDistance : MonoBehaviour
{
    public Text DistanceText;
    public Transform Helicopter;
    public Transform Player;

    private float distance;

    private void Update()
    {
        if (Player == null) return;
        distance = Player.position.y - Helicopter.position.y;
        DistanceText.text = distance.ToString();
    }
}
