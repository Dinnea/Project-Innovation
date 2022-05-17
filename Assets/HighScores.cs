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
    public GameObject[] items;

    private static HighScores originalScores;

    private void Awake()
    {
        /*DontDestroyOnLoad(this.transform.parent.gameObject);
        if (originalScores == null)
        {
            originalScores = this;
        }
        else
        {
            Destroy(this.transform.parent.gameObject);
        }*/
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        UpdateHighScoreText();
        DisableHighScores();
    }

    private void Update()
    {
        _scores = scores;
    }


    public static void AddHighScore(float points)
    {
        //Load();
        bool add = true;
        foreach(float i in scores)
        {
            if (i == points)
            {
                add = false;
                break;
            }
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
        SaveSystem.SaveHighScores();
    }

    public void UpdateHighScoreText()
    {
        Load();
        for (int i = 0; i < scores.Count; i++)
        {
            texts[i].text = scores[i].ToString();
            Debug.Log(scores[i]);
        }

    }

    public void DisableHighScores()
    {
        foreach( GameObject item in items)
        {
           item.SetActive(false);
        }
    }

    public void EnableHighScores()
    {
        foreach (GameObject item in items)
        {
            item.SetActive(true);
        }
    }


    public void Save()
    {
        SaveSystem.SaveHighScores();
    }
     public static void Load()
    {
        HighScoreData data = SaveSystem.LoadData();
        scores = data.savedScores;
    }

}
