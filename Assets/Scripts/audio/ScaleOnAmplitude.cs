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
    public bool scaleX, scaleY, scaleZ, is3D;
    Vector3 defaultScale;
    //[SerializeField] float treshold = 0.2f;

    private void Awake()
    {
        defaultScale = transform.localPosition;
       if(is3D) material = GetComponent<MeshRenderer>().materials[0];
    }

    private void Update()
    {
        if (!useBuffer)
        {
            Scale(AudioData.amplitude, AudioData.treshold);
        }
       else
        {
            Scale(AudioData.amplitudeBuffer, AudioData.treshold);
        }
    }

    void Scale(float amplitude, float treshold = 0)
    {
        if (amplitude > treshold)
        {
            Vector3 newScale = new Vector3((amplitude * maxScale) + startScale, (amplitude * maxScale) + startScale, (amplitude * maxScale) + startScale);
            if (!scaleX) newScale.x = defaultScale.x;
            if (!scaleY) newScale.y = defaultScale.y;
            if (!scaleZ) newScale.z = defaultScale.z;
            transform.localScale = newScale;
            if (is3D)
            {
                Color color = new Color(red * amplitude, green * amplitude, blue * amplitude);
                material.SetColor("_EmissionColor", color);
            }
        }
        else transform.localScale = defaultScale;
    }
}
