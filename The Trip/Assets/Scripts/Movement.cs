using UnityEngine;

//This script is a clean powerful solution to a top-down movement player
public class Movement : MonoBehaviour
{
    //Animation
    private Animator animator;
    //For player facing direction
    private SpriteRenderer sprite;
    public static bool rightDirection;
    //Public variables that wer can edit in the editor
    public float maxSpeed = 5; //Our max speed
    public float acceleration = 20; //How fast we accelerate
    public float deacceleration = 4; //brake power
    //Jump variables
    public float jumpPower = 10;
    public float groundCheckDistance = 0.1f;
    float jumpButtonPressedTime;
    bool onGround = true;
    float groundCheckLenght;

    float velocityX; //Our current velocity

    Rigidbody2D rb2D; //Ref to our rigidbody

    private void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        Physics2D.queriesStartInColliders = false;
        rb2D = GetComponent<Rigidbody2D>(); //assign our ref.

        var collider = GetComponent<Collider2D>();
        groundCheckLenght = collider.bounds.size.y + 0.1f;
    }

    void Update()
    {

        MovementX();

        if (Input.GetButtonDown("Jump") && onGround)
        {
            animator.SetTrigger("Jumping");
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
            jumpButtonPressedTime = Time.time;
        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0 && Time.time - jumpButtonPressedTime <= 0.1)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.25f);
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLenght);

        if (rb2D.velocity.x > -0.3f && rb2D.velocity.x < 0.3f && onGround)
        {
            animator.SetBool("IsWalking", false);   
        }
        else if (onGround)
        {
            animator.SetBool("IsWalking", true);
        }

        if (rb2D.velocity.y < 0)
        {
            rb2D.gravityScale = 4;
        }
        else
        {
            rb2D.gravityScale = 2;
        }
    }

    private void MovementX()
    {
        //Lower movement speed when holding a object
        if (GrabOjectScript.holding)
        {
            maxSpeed = 2.5f;
            jumpPower = 7.5f;
        }
        else
        {
            maxSpeed = 5;
            jumpPower = 10;
        }

        if (!onGround)
            acceleration = 10;
        else
            acceleration = 20;

        //Get the raw input
        float x = Input.GetAxisRaw("Horizontal");

        //add our input to our velocity
        //This provides accelleration +10m/s/s
        velocityX += x * acceleration * Time.deltaTime;

        //Check our max speed, if our magnitude is faster them max speed
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        //If we have zero input from the player
        if (x == 0 || (x < 0 == velocityX > 0))
        {
            //Reduce our speed based on how fast we are going
            //A value of 0.9 would remove 10% or our speed
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        //Now we can move with the rigidbody and we get propper collisions
        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);

        if (rb2D.velocity.x < 0)
        {
            rightDirection = false;
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if (rb2D.velocity.x > 0)
        {
            rightDirection = true;
            transform.eulerAngles = new Vector3(0,0,0);
        }
    }

}
