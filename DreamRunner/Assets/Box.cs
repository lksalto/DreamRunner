using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject explosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject exp;
        if(collision.gameObject.CompareTag("Enemy"))
        {
            exp = Instantiate(explosionEffect, gameObject.transform) ;
            exp.transform.parent = null;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
