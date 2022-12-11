using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    public MeshRenderer mr;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2(speed * Time.deltaTime,0);
    }

    // Update is called once per frame
    void Update()
    {
            movement = new Vector2(speed * Time.deltaTime, 0f);
            mr.material.mainTextureOffset += movement;
    }
}
