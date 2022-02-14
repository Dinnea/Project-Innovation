using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour
{
    public float startScale, maxScale;
    public bool useBuffer;
    Material material;
    [Space]
    public float red, green, blue;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (!useBuffer)
        {
            transform.localScale = new Vector3((AudioData.amplitude * maxScale) + startScale, (AudioData.amplitude * maxScale) + startScale, (AudioData.amplitude * maxScale) + startScale);
            Color color = new Color(red * AudioData.amplitude, green * AudioData.amplitude, blue * AudioData.amplitude);
            material.SetColor("_EmissionColor", color);
        }
       else
        {
            transform.localScale = new Vector3((AudioData.amplitudeBuffer * maxScale) + startScale, (AudioData.amplitudeBuffer * maxScale) + startScale, (AudioData.amplitudeBuffer * maxScale) + startScale);
            Color color = new Color(red * AudioData.amplitudeBuffer, green * AudioData.amplitudeBuffer, blue * AudioData.amplitudeBuffer);
            material.SetColor("_EmissionColor", color);
        }
    }
}
