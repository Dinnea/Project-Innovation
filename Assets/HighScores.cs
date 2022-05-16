using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public static List<float> scores = new List<float>();
    public List<float> _scores;
    public static float newScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform.parent.gameObject);
    }

    private void Update()
    {
        _scores = scores;
    }


    public static void CreateScore(float points)
    {
        bool add = true;
        foreach(float i in scores)
        {
            if (i == points) add = false; break;
        }
        if (add)
        {
            scores.Add(points);
            scores.Sort();
            scores.Reverse();
            if (scores.Count > 5)
            {
                scores.RemoveAt(scores.Count - 1);
            }
        }

    }

}
