using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalFinder : MonoBehaviour
{
    public float Walled;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==6)Walled += 1;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) Walled -= 1;
    }
    
}
