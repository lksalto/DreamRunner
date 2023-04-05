using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] SoundManager sm;

    public float moveSpeed;
    public float jumpForce;
    public int maxjumpCount = 1;
    public Transform groundCheck;
    public LayerMask groundObjects;
    //public LayerMask OtherWorld;
    public Vector3 boxSize = new (0.005f,0.005f, 0);

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
        //verifica se o player está no chão
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
        rb.velocity = new Vector2(moveDirection * moveSpeed * Time.deltaTime, rb.velocity.y);
        if (isJumping && jumpCount > 0)
        {
            Vector2 temp = rb.velocity;
            temp[1] = 0f;
            rb.velocity = temp;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animar()
    {
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipCharacter();
            anim.SetBool("walking", isGrounded);
            anim.SetBool("jumping", !isGrounded);
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipCharacter();
            anim.SetBool("walking", isGrounded);
            anim.SetBool("jumping", !isGrounded);
        }
        else if (moveDirection == 0)
        {
            anim.SetBool("walking", false);
            anim.SetBool("jumping", !isGrounded);
        }

        
    }

    private void ProcessarInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.PlayJumpSound();
            isJumping = true;
            
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void FlipCharacter() {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
