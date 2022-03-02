using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Waves")]
    static List<Wave> waves = new List<Wave>();
    [SerializeField] List<Wave> inspector;
    static Wave currentWave;
    static int currentWaveNr;

    private void Awake()
    {
        waves = inspector;
        SetCurrentWave(0);
    }
    public static void SetCurrentWave(int number)
    {
        currentWaveNr = number;
        if (number < waves.Count) currentWave = waves[number];
        else Debug.Log("no more waves");
    }
    public static void NextWave()
    {
        SetCurrentWave(currentWaveNr + 1);
    }
    public static Wave GetCurrentWave()
    {
        return currentWave;
    }

    public static int GetWaveNumber()
    {
        return currentWaveNr;
    }

    public static void AddWave(Wave wave)
    {
        waves.Add(wave);
    }
   
}
