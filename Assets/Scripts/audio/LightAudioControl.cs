using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightAudioControl : MonoBehaviour
{
    public int band;
    public float minIntensity, maxIntensity;
    Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        _light.intensity = (AudioData.audioBandBuffer[band] * (maxIntensity - minIntensity)) + minIntensity;
    }
}
