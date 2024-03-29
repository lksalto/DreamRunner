using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIcomplex : MonoBehaviour
{
    public GameObject Wallfind;
    public GameObject Sight;
    private Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;
    public float mvspdbkup;
    public float deaceleration;
    public bool jumped;
    private bool isFacingRight = true;
    private Animator anim;
    public bool grounded;
    public Transform Groundcheck;
    public LayerMask groundlayers;
    public Vector2 groundbox = new (1, 1);

    private void Start()
    {
        mvspdbkup = moveSpeed;
        moveSpeed = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        grounded = Physics2D.OverlapBox(Groundcheck.position, groundbox, 0f, groundlayers);

        if (Sight.GetComponent<sight>().SeePlayer)
        {
            moveSpeed = mvspdbkup;
            rb.velocity = new Vector2(Sight.GetComponent<sight>().PlayerIsOnRightOrLeft * moveSpeed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            moveSpeed -= deaceleration*Time.deltaTime;
            if(moveSpeed < 0) { moveSpeed = 0; }
            rb.velocity = new Vector2(Sight.GetComponent<sight>().PlayerIsOnRightOrLeft * moveSpeed * Time.deltaTime, rb.velocity.y);
        }

        //jump when wall
        if (Wallfind.GetComponent<EnemyWalFinder>().Walled == 1 && jumped == false)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumped = true;
            Wallfind.GetComponent<EnemyWalFinder>().Walled += 1;
        }

        if (rb.velocity.x > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (rb.velocity.x < 0 && isFacingRight)
        {
            FlipCharacter();
        }
    }
    void AnotherJumpTime()
    {
        jumped = false;
        Wallfind.GetComponent<EnemyWalFinder>().Walled -= 1;//==2
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && jumped && grounded) { AnotherJumpTime(); }
    }
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
