using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPC : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private Vector3 moveDirection;
    [SerializeField]private float movementSpeed;
    private Rigidbody rb;
    Bounce bounce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bounce = GetComponent<Bounce>();
    }
    private void Update()
    {
        if(!bounce.isGrounded) playerMove();
    }
    Vector3 getDirection()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, vertical, 0).normalized;
        return moveDirection;
    }

    void playerMove()
    {
        moveDirection = getDirection();

        if (moveDirection.magnitude >= 0.01f)
        {
            Vector3 move = moveDirection * movementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(transform.position + move);

        }
    }
}
