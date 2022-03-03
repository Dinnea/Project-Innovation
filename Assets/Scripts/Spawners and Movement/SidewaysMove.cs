using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMove : MonoBehaviour
{
    [SerializeField] private float Xpos1;
    [SerializeField] private float Xpos2;
    [SerializeField] private Vector3 fineTuneTurn = new Vector3(0.1f, 0, 0);
    [SerializeField] private float time;
    Rigidbody2D rb;
    void MoveBody(Rigidbody2D body, Vector3 from, Vector3 to, float time)
    {
        body.MovePosition(Vector3.Lerp(from, to, time));
       /* if (transform.position.x <= Xpos1)
        {
           //spriteRenderer.flipY = true;
        }
        if (transform.position.x >= Xpos2) spriteRenderer.flipY = false;*/
    }

   
    
    public float speed = 1.0f;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        Vector3 pos1 = new Vector3(Xpos1, transform.position.y);
        Vector3 pos2 = new Vector3(Xpos2, transform.position.y);
        MoveBody(rb, pos2 + fineTuneTurn, pos1 - fineTuneTurn, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    void transformPosition()
    {
        Debug.Log("Is this used anywhere?");
        /*
        transform.position = Vector3.Lerp(Xpos1, Xpos2, Mathf.PingPong(Time.time * speed, 1.0f));
        if (transform.position == Xpos1)
        {
            spriteRenderer.flipY = true;
        }
        if (transform.position == Xpos2) spriteRenderer.flipY = false;
        */
    }
}
