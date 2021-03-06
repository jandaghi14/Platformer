using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public int movespeed;
    public int jumppower;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public int coins;
    public bool moveLeft, moveRight; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movespeed = 3;
        jumppower = 8;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }

        if (moveRight || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }

        if (Input.GetKey(KeyCode.Space) )
        {
            jump();
        }
    }

    public void jump()
    {
        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);

        }
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround); 
    }
}
