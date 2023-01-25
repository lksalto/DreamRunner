using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Transform jumpheight;
    public float jumpspeed=4;
    public float jumpspeedbackup;
    public float gravity;
    public float Timer=0;

    public float Hspeed=3;

    public Vector3 mousepos;
    public Vector3 mousexpos;
    public Transform StartPos;
    public int jumped;
    // Start is called before the first frame update
    void Start()
    {
        jumpspeedbackup=jumpspeed;
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 0f;
        mousexpos = new Vector3(mousepos.x, transform.position.y, 0f);
        Jump();
        Move();
    }
    private void Move()
    {
        if (Input.GetMouseButton(0)) 
        {
            transform.position = Vector3.MoveTowards(transform.position, mousexpos, Hspeed * Time.deltaTime);
        }
    }
    void Jump() 
    {
        if (jumpspeed < 0f) { jumpspeed = 0f; jumped = 1; }
        if (Input.GetButton("Jump") && jumped != 1)
        {
            Timer+=Time.deltaTime;
            jumpspeed -= gravity * Time.deltaTime;
            jumped = 2;
            transform.position = Vector3.MoveTowards(transform.position, jumpheight.position, jumpspeed * Time.deltaTime);
        }
        if(Input.GetButtonUp("Jump")&&jumped==2)
        {
            jumped = 1;
            jumpspeed -= gravity*Timer;
        }
        if(jumped == 1)
        {
            jumpspeed += gravity * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position, jumpspeed * Time.deltaTime);
        }
        if (transform.position == StartPos.position&&jumped!=0)
        {
            jumped = 0;
            Timer=0;
            jumpspeed = jumpspeedbackup;
        }
    }
}
