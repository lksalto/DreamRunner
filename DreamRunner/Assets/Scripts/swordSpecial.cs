using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSpecial : MonoBehaviour
{
    public GameObject ghost;

    public float speed;
    public float SwordDistance;
    public Transform StartPos;
    public bool ClickToReturn;

    private float Distance;
    private Vector3 Swordclicked;
    private int position;
    private bool flipped;
    private bool parede;

    void Update()
    {
        //Flipa se tiver ao contrario
        if (transform.localEulerAngles.y == 180|| transform.localEulerAngles.y == -180) { transform.Rotate(-180f, 0f, 0f);/*transform.localEulerAngles = new Vector3(0f, 0f, -90f); }/*/}

            //Inverte distancia para quando flipa//por alguma razão ele flipa em -1 e não -180...
            if (ghost.transform.eulerAngles.y >= 180)
                {
                    Distance = -SwordDistance;
                    if (!flipped) { flipped = true; }
                }
                else { Distance = SwordDistance; if (flipped) { flipped = false; } }

                //Se chega na posição inicial
                if (transform.position == StartPos.position)
                {
                    position = 0;
                    transform.SetParent(StartPos);
                    //pra permitir um click só
                    if (Input.GetMouseButtonDown(0)) { position = 2; }


                }
                //Se chega na posição final
                if (transform.position == Swordclicked) position = 1;
                //Calcula a posição final
                if (transform.position == StartPos.position) Swordclicked = new Vector3(transform.position.x + Distance, transform.position.y, transform.position.z);

                //se o mouse estiver pressionado
                if (Input.GetMouseButton(0) && position == 2 && !parede)
                {
                    //Se torna independente
                    transform.SetParent(ghost.transform.parent);
                    //Vai até a posição final
                    transform.position = Vector3.MoveTowards(transform.position, Swordclicked, speed * Time.deltaTime);
                }
                //Se não volta pra inicial
                else if (!ClickToReturn)
                {
                    transform.position = Vector3.MoveTowards(transform.position, StartPos.position, speed * Time.deltaTime);
                    if (parede) position = 1;
                }
                //Só volta clicando com o direito
                if (Input.GetMouseButton(1) && ClickToReturn) { transform.position = Vector3.MoveTowards(transform.position, StartPos.position, speed * Time.deltaTime); }
            }
            void OnTriggerEnter2D(Collider2D collision)
            {
                if (collision.gameObject.layer == 6 || collision.gameObject.layer == 9)
                {
                    if(!collision.gameObject.CompareTag("Enemy"))parede = true;
                }
            }
            void OnTriggerExit2D(Collider2D collision)
            {
                parede = false;
            }
        }
