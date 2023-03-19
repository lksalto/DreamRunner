using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life=2;
    public bool enemy;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike")) 
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
        }
        if (collision.gameObject.CompareTag("Mario")&&enemy)
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mario") && enemy)
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
        }
    }
}
