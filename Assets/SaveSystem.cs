using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   public static void SaveHighScores()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath +"/scores.pogo";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreData data = new HighScoreData(true);

        formatter.Serialize(stream, data);
        stream.Close();
   }

    public static HighScoreData LoadData()
    {
        string path = Application.persistentDataPath + "/scores.pogo";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HighScoreData data = formatter.Deserialize(stream) as HighScoreData;
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
