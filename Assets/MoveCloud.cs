using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    [SerializeField] [Range(0f, 4f)] float lerpTime;
    [SerializeField] Vector3[] myPos;
    int length;


    float t = 0f;

    private void Start()
    {
        Debug.Log(Screen.width / 2);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(screenPos);
        length = myPos.Length;
        myPos[0].y = transform.position.y;
        myPos[1].y = transform.position.y;
    }

    private void Update()
    {

        if(AudioData.amplitude > AudioData.treshold)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            if (screenPos.x < Screen.width / 2)
            {
                Debug.Log("left");
                MovingClouds(0);
            }
            else if (screenPos.x > Screen.width / 2)
            {
                MovingClouds(1);
                Debug.Log("right");
            }
           
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

