using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight : MonoBehaviour
{
    public bool SeePlayer;
    public int PlayerIsOnRightOrLeft;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if(collision.gameObject.CompareTag("Player")) 
        {
            Player=collision.gameObject;
            SeePlayer=true;
            
        
            if (collision.gameObject.transform.position.x > transform.position.x) 
            {
                PlayerIsOnRightOrLeft = 1;
            }
            else if(collision.gameObject.transform.position.x < transform.position.x) 
            {
                PlayerIsOnRightOrLeft = -1;
            } else { PlayerIsOnRightOrLeft = 0; }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = null;
            SeePlayer=false;
        }
    }
}
