using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMove : MonoBehaviour
{
    [SerializeField] private Vector3 pos1 = new Vector3(-4, 0.1f, 0);
    [SerializeField] private Vector3 pos2 = new Vector3(4, 0.1f, 0);
    [SerializeField] private Vector3 fineTuneTurn = new Vector3(0.1f, 0, 0);
    [SerializeField] private float time;
    Rigidbody2D rb;
    void MoveBody(Rigidbody2D body, Vector3 from, Vector3 to, float time)
    {
        body.MovePosition(Vector3.Lerp(from, to, time));
        if (transform.position.x <= pos1.x)
        {
            spriteRenderer.flipY = true;
        }
        if (transform.position.x >= pos2.x) spriteRenderer.flipY = false;
    }

   
    
    public float speed = 1.0f;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        MoveBody(rb, pos2 + fineTuneTurn, pos1- fineTuneTurn, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    void transformPosition()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        if (transform.position == pos1)
        {
            spriteRenderer.flipY = true;
        }
        if (transform.position == pos2) spriteRenderer.flipY = false;
    }
}
