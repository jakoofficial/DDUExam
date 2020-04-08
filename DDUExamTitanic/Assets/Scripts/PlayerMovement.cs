using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;

    public bool moveable = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (moveable)
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(hAxis * speed, vAxis * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
