using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoting : MonoBehaviour
{
    public GameObject[] ativar;
    private bool minion;
    private Player_Movement playerscript;
    public float returnspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        playerscript = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Minion();
        for (int i = 0; i < ativar.Length; i++)
        {
            if (!minion)
            {
                ativar[i].GetComponent<Transform>().position = Vector3.MoveTowards(ativar[i].transform.position, transform.position, returnspeed * Time.deltaTime);
                if (ativar[i].transform.position == transform.position)
                {
                    ativar[i].SetActive(false);
                }
            }
        }
    }

    void Minion()
    {
        if (Input.GetKeyDown("e"))
        {

            for (int i = 0; i < ativar.Length; i++)
            {
                
                if (minion)
                {
                    ativar[i].GetComponent<Player_Movement>().enabled = false;
                    
                        ativar[i].GetComponent<Collider2D>().enabled = false;
                        ativar[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    

                }
                else
                {

                    ativar[i].GetComponent<Player_Movement>().enabled = true;
                    
                        ativar[i].GetComponent<Collider2D>().enabled = true;
                        ativar[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                        ativar[i].SetActive(true);
                        ativar[i].transform.position = transform.position;
                    
                }
            }
            minion = !minion;
            playerscript.enabled = !minion;
        }
    }
}
