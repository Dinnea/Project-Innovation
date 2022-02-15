using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    [SerializeField] [Range(0f, 4f)] float lerpTime;
    [SerializeField] Vector3[] myPos;
    int length;

    [SerializeField] float treshold = 0.5f;
    float t = 0f;

    private void Start()
    {
        length = myPos.Length;
    }

    private void Update()
    {
        if(AudioData.amplitude > treshold)
        {
            MovingClouds(0);
        }
    }

    void MovingClouds(int posIndex)
    {
        transform.position = Vector3.Lerp(transform.position, myPos[posIndex], lerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);

        if (t > 0.9f)
        {
            t = 0f;
        }
    }
}

