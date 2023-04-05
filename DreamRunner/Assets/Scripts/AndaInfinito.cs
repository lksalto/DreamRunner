using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndaInfinito : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isFacingRight = true;
    private int moveDirection;
    public float moveSpeed;
    public bool direita;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (direita) moveDirection = 1;
        else moveDirection = -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (moveDirection > 0 && !isFacingRight)
        {
            FlipCharacter();
            anim.SetBool("walking", true);
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipCharacter();
            anim.SetBool("walking", true);
        }
        else if (moveDirection == 0)
        {
            anim.SetBool("walking", false);
        }


    }
}
