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
    [SerializeField] float treshold = 0.2f;

    private void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (!useBuffer)
        {
            Scale(AudioData.amplitude, treshold);
        }
       else
        {
            Scale(AudioData.amplitudeBuffer, treshold);
        }
    }

    void Scale(float amplitude, float treshold = 0)
    {
        if (amplitude > treshold)
        {
            transform.localScale = new Vector3((amplitude * maxScale) + startScale, (amplitude * maxScale) + startScale, (amplitude * maxScale) + startScale);
            Color color = new Color(red * amplitude, green * amplitude, blue * amplitude);
            material.SetColor("_EmissionColor", color);
        }
        else transform.localScale = new Vector3(startScale, startScale, startScale);
    }
}
