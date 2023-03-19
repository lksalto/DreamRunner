using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float life;
    public GameObject Hitbox;
    public GameObject[] WhenDead;
    public Behaviour[] beh;
    public Text text;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    //private Collider2D Col;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        Hitbox.GetComponent<Life>().life = life;
        sr = GetComponent<SpriteRenderer>();
        rb= GetComponent<Rigidbody2D>();
        //Col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        life= Hitbox.GetComponent<Life>().life;
        text.text = life.ToString();
        if (life <= 0 && !dead)
        {
            dead = true;
            sr.enabled = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector3(0f, 0f, 0f);
            //Col.enabled = false;
            for (int i = 0; i < WhenDead.Length; i++)
            {
                WhenDead[i].SetActive(!WhenDead[i].activeSelf);
            }
            for (int i = 0; i < beh.Length; i++)
            {
                beh[i].enabled = false;//!beh[i].enabled;
            }
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Mario"))
        {
            life -= collision.gameObject.GetComponent<Damage>().damage;
        }
    }*/
}
