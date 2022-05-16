using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public static List<float> scores = new List<float>();
    public List<float> _scores;
    public static float newScore;
    public TextMeshProUGUI[] texts;


    private void Awake()
    {
        DontDestroyOnLoad(this.transform.parent.gameObject);
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        LoadHighScoreData();
    }

    private void Update()
    {
        _scores = scores;
    }


    public static void AddHighScore(float points)
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

    public void UpdateHighScoreText()
    {
        for (int i = 0; i < scores.Count; i++)
        {
            texts[i].text = scores[i].ToString();
        }

    }

    public void LoadHighScoreData()
    {
       
        UpdateHighScoreText();
    }

    
    public void Save()
    {
        SaveSystem.SaveHighScores();
    }
     public void Load()
    {
        HighScoreData data = SaveSystem.LoadData();
        scores = data.savedScores;
    }

}
