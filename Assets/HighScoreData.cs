using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public List<float> savedScores;

    public HighScoreData(bool asdf)
    {
        savedScores = HighScores.scores;
    }
}
