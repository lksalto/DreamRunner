using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int maxjumpCount = 1;
    public Transform groundCheck;
    public LayerMask groundObjects;
    //public LayerMask OtherWorld;
    public Vector2 boxSize = new (1,1);

    private int jumpCount;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;

    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tratando os inputs do player
        ProcessarInputs();

        //Animar
        Animar();

        

    }


    private void FixedUpdate()
    {
        //verifica se o player est� no ch�o
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0f, groundObjects);

        if (isGrounded)
        {
            jumpCount = maxjumpCount;
        }

        //mover
        Mover();
    }

    private void Mover()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping && jumpCount > 0)
        {
            Vector2 temp = rb.velocity;
            temp[1] = 0f;
            rb.velocity = temp;
            rb.AddForce(new Vector2(0f, jumpForce));
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animar()
    {
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipCharacter();
            anim.SetBool("walking", true);
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipCharacter();
            anim.SetBool("walking", true);
        } else if (moveDirection == 0)anim.SetBool("walking", false);
    }

    private void ProcessarInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FlipCharacter() {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
