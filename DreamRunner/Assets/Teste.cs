using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public GameObject Wallfind;
    public GameObject Sight;
    private Rigidbody2D rb;
    public float jumpForce;
    public float moveSpeed;
    public bool jumped;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Sight.GetComponent<sight>().SeePlayer) 
        {
            rb.velocity = new Vector2(Sight.GetComponent<sight>().PlayerIsOnRightOrLeft*moveSpeed * Time.deltaTime, rb.velocity.y);
        }

       //jump when wall
        if (Wallfind.GetComponent<EnemyWalFinder>().Walled == 1&& jumped==false) 
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumped = true;
        }
    }
    void AnotherJumpTime() 
    {
        jumped=false;
        Wallfind.GetComponent<EnemyWalFinder>().Walled = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && jumped) {AnotherJumpTime();}
    }
}
