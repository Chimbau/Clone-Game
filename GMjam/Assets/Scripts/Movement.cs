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
    public float AirMovementForce = 2f;

    public float checkRadius;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public Transform wallCheck;
    public float wallCheckDistance;
    private bool isInWall;
    private bool isWallSliding = false;
    public float wallSlidingSpeed;

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;
    public float wallHopForce;
    public float wallJumpForce;
    public float airDragMultiplier = 0.05f;



    private bool virou = true;
    private int facingDirection = 1;
    private bool Grounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        CheckWallSliding();
        PlayerInput();
        HorizontalMovement();
        VerticalMovement();
      
        //OnDrawGizmos();
    }

    void FixedUpdate()
    {
        Grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isInWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
    }


    public void PlayerInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }


    public void HorizontalMovement()
    {

      
        if (Grounded)
        {
            rb.velocity = new Vector2(xAxis * movespeed, rb.velocity.y);
        }
        else if (!Grounded && !isWallSliding && xAxis != 0)
        {
            if (isWallSliding == false)
            {
                Vector2 forceToAdd = new Vector2(AirMovementForce * xAxis, 0);
                rb.AddForce(forceToAdd);

                if (Mathf.Abs(rb.velocity.x) > movespeed && Mathf.Abs(rb.velocity.x) < 15)
                {
                    Debug.Log("Entro");
                    rb.velocity = new Vector2(movespeed * xAxis, rb.velocity.y);
                }
   
            }
            
            
            
        }
        else{
            if (!Grounded && !isWallSliding && xAxis == 0)
            {
                if (rb.velocity.x < 20)
                {
                    rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
                }
                
            }
        }
       

        if (xAxis > 0 && virou == false)
        {
            transform.Rotate(0, 180, 0);
            facingDirection = 1;
            virou = true;
        }

        if (xAxis < 0 && virou == true)
        {
            transform.Rotate(0, 180, 0);
            facingDirection = -1;
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


        if (isWallSliding)
        {
            if (rb.velocity.y < -wallSlidingSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
            }
        }

        /*if (jump)
        {
            if (isWallSliding && xAxis == 0)
            {
                isWallSliding = false;
                Vector2 forceToAdd = new Vector2(wallHopForce * wallHopDirection.x * -facingDirection, wallHopForce * wallHopDirection.y);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);

            }
            else if ((isWallSliding || isInWall) && xAxis != 0)
            {
                isWallSliding = false;
                Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * xAxis, wallJumpForce * wallJumpDirection.y);
                rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            }
        }*/

    }

    public bool isGrounded()
    {
        return Grounded;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }


    private void CheckWallSliding()
    {
        if (isInWall && rb.velocity.y < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }






}
