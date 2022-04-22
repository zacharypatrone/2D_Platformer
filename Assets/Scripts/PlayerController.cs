using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    Vector2 movement;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpPower = 300;
    float horizontalValue;

    bool facingRight = true;
    [SerializeField] bool isGrounded = false;
    bool jump = false;

    public static int numCoins;
    public TextMeshProUGUI coinCounterText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
        HandleInput();
        HandleAnimation();
        LogCounter();

    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontalValue, jump);
    }

    void Move(float direction, bool hasJumped)
    {
        // set x value using direction and speed
        float xValue = direction * speed * 100 * Time.deltaTime;
        Vector2 targetVelocity = new Vector2(xValue, rb.velocity.y);
        //sets players velocity
        rb.velocity = targetVelocity;

        // if looking right and click left, then flip player
        if (facingRight && direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        // if looking left and click right, then flip player
        else if (!facingRight && direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }

        // if player if grounded and space is pressed then jump
        if (isGrounded && hasJumped)
        {
            isGrounded = false;
            hasJumped = false;
            // add jump force
            rb.AddForce(new Vector2(0f, jumpPower));
        }

        
    }

    // store the horizontal value
    void HandleInput()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontalValue, 0);

        // enables jump one time when pressed
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }

    void HandleAnimation()
    {
        animator.SetFloat("SquareMagnitude", movement.sqrMagnitude);
    }


     // checks if ground check object is colliding with other 2d colliders
     void GroundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
    }

    void LogCounter()
    {
        coinCounterText.text = "x" + numCoins;
    }

}
