using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AwakePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.right * moveSpeed * Time.deltaTime;
    }
}
