using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndaInfinito : MonoBehaviour
{
    private Rigidbody2D rb;
    private int moveDirection;
    public float moveSpeed;
    public bool direita;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (direita) moveDirection = 1;
        else moveDirection = -1;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }
}
