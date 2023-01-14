using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSpecial : MonoBehaviour
{
    public Transform ghost;
    public float speed;
    public float SwordDistance;
    private float Distance;
    public Transform StartPos;
    private Vector3 Swordclicked;
    private int position;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ghost.rotation.y == -180) { Distance = -SwordDistance; }
        else { Distance = SwordDistance; }
        if (transform.position == StartPos.position)
        {
            position = 0;
            if (Input.GetMouseButtonDown(0)) {position = 2;}
        }
        if(transform.position == Swordclicked) position=1;

        if(transform.position == StartPos.position) Swordclicked = new Vector3(transform.position.x+Distance,transform.position.y,transform.position.z);

        if (Input.GetMouseButton(0)&&position==2) 
        {
            transform.position = Vector3.MoveTowards(transform.position, Swordclicked, speed * Time.deltaTime); 
        }
        else transform.position = Vector3.MoveTowards(transform.position, StartPos.position, speed * Time.deltaTime);
    }
}
