using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    private Rigidbody2D rb;
    public float movespeed;
    
    private float xAxis;

    private bool jump;
    public float jumpForce;
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2f;

    public float checkRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool virou = true;
    private bool Grounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        HorizontalMovement();
        VerticalMovement();
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }


    public void PlayerInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }


    public void HorizontalMovement()
    {
        rb.velocity = new Vector2(xAxis * movespeed, rb.velocity.y);

        if (xAxis > 0 && virou == false)
        {
            transform.Rotate(0, 180, 0);
            virou = true;
        }

        if (xAxis < 0 && virou == true)
        {
            transform.Rotate(0, 180, 0);
            virou = false;
        }
    }

    public void VerticalMovement()
    {


        if (jump && Grounded && !Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public bool isGrounded()
    {
        return Grounded;
    }







}
