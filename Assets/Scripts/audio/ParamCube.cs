using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
    Material material;

    private void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().materials[0];
    }
    private void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                            (AudioData.audioBandBuffer[band] * scaleMultiplier) + startScale,
                                            transform.localScale.z);
            Color color = new Color(AudioData.audioBandBuffer[band], AudioData.audioBandBuffer[band], AudioData.audioBandBuffer[band]);
            material.SetColor("_EmissionColor", color);
           
        }
        else 
        {
            transform.localScale = new Vector3(transform.localScale.x,
                                            (AudioData.audioBand[band] * scaleMultiplier) + startScale,
                                            transform.localScale.z);
            Color color = new Color(AudioData.audioBand[band], AudioData.audioBand[band], AudioData.audioBand[band]);
            material.SetColor("_EmissionColor", color);
        }
        
    }
}
