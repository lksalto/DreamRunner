using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSpecial : MonoBehaviour
{
    public GameObject ghost;

    public float speed;
    public float SwordDistance;
    public Transform StartPos;

    private float Distance;
    private Vector3 Swordclicked;
    private int position;
    public bool flipped;

    void Update()
    {
        if(transform.localEulerAngles.y ==180)transform.Rotate(-180f,0f,0f);

        //Inverte distancia para quando flipa//por alguma raz�o ele flipa em -1 e n�o -180...
        if (ghost.transform.eulerAngles.y >=180) 
        {
            Distance = -SwordDistance;
            if (!flipped) { flipped = true; }
        }
        else { Distance = SwordDistance; if (flipped) {flipped = false; } }

        //Se chega na posi��o inicial
        if (transform.position == StartPos.position)
        {
            position = 0;
            transform.SetParent(StartPos);
            //pra permitir um click s�
            if (Input.GetMouseButtonDown(0)) {position = 2; }
            

        }
        //Se chega na posi��o final
        if(transform.position == Swordclicked) position=1;
        //Calcula a posi��o final
        if(transform.position == StartPos.position) Swordclicked = new Vector3(transform.position.x+Distance,transform.position.y,transform.position.z);

        //se o mouse estiver pressionado
        if (Input.GetMouseButton(0)&&position==2) 
        {
            transform.SetParent(ghost.transform.parent);
            //Vai at� a posi��o final
            transform.position = Vector3.MoveTowards(transform.position, Swordclicked, speed * Time.deltaTime); 
        }
        //Se n�o volta pra inicial
        else transform.position = Vector3.MoveTowards(transform.position, StartPos.position, speed * Time.deltaTime);
        //S� volta clicando com o direito
        ///if(Input.GetMouseButton(1)) { transform.position = Vector3.MoveTowards(transform.position, StartPos.position, speed * Time.deltaTime); }
    }
}
