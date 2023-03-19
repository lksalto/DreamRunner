using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 1f;
    public bool bounce;
    public Vector3 bounceforce;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&&bounce)
        {
            GetComponentInParent<Player_Movement>().enabled = false;
            if (transform.position.x<collision.transform.position.x) { GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(bounceforce.x, bounceforce.y), ForceMode2D.Impulse); }
            else if (transform.position.x>collision.transform.position.x) { GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(-bounceforce.x, bounceforce.y), ForceMode2D.Impulse); }
            Invoke("EnablePlayermove", bounceforce.z);
        }
    }
    private void EnablePlayermove() 
    {
        GetComponentInParent<Player_Movement>().enabled = true;
    }
}
