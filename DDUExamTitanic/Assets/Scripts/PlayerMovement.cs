using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;
    public Animator anim;

    public bool moveable = true;
    private bool isRight = true;

    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (moveable)
        {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
            anim.SetFloat("Speed", movement.sqrMagnitude);
        } 
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate()
    {
        if (moveable)
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void FlipX(bool flip)
    {
        this.GetComponent<SpriteRenderer>().flipX = flip;
    }
}
