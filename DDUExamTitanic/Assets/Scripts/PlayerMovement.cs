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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (moveable)
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");

            if (hAxis > 0)
            {
                anim.SetBool("WalkingSides", true);
                FlipX(false);
            }
            else if (hAxis < 0)
            {
                anim.SetBool("WalkingSides", true);
                FlipX(true);
            }
            else if (hAxis == 0)
            {
                anim.SetBool("WalkingSides", false);
            }

            rb.velocity = new Vector2(hAxis * speed, vAxis * speed);
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
