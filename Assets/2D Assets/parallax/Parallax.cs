using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float size, startPosition;
    [SerializeField]GameObject cam;
    [SerializeField][Range(0f, 1f)] float parallaxEffect;
    [SerializeField] bool horizontal, vertical;

    private void Start()
    {
        if (horizontal)
        {
            startPosition = transform.position.x;
            size = GetComponent<SpriteRenderer>().bounds.size.x;
        }
        else if (vertical)
        {
            startPosition = transform.position.y;
            size = GetComponent<SpriteRenderer>().bounds.size.y;
        }
       
    }

    private void FixedUpdate()
    {
        float temp;
        float distance;

        if (horizontal)
        {
            temp = (cam.transform.position.x * (1 - parallaxEffect));
            distance = (cam.transform.position.x * parallaxEffect);
            transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        }
        else if (vertical)
        {
            temp = (cam.transform.position.y * (1 - parallaxEffect));
            distance = (cam.transform.position.y * parallaxEffect);
            transform.position = new Vector3(transform.position.x, startPosition + distance, transform.position.z);
        }
        else
        {
            temp = 0;
            distance = 0;
            Debug.Log("No parallax direction selected.");
        }


        if (temp > startPosition + size) startPosition += size;
        else if (temp < startPosition - size) startPosition -= size;
    }

}
