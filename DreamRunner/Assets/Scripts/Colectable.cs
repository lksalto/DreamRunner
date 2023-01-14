using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour
{
    private SpriteRenderer sr;
    private Collider2D col;
    public GameObject[] Colects;
    public float lifeadd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Life>().life += lifeadd;
            //dissapear?
            sr.enabled = false;
            col.enabled = false;
            //Call Colect Objects
            for (int i = 0; i < Colects.Length; i++)
            {
                Colects[i].SetActive(!Colects[i].activeSelf);
            }
            //Completly dissapear
            Destroy(gameObject, 1f);
        }
    }
}
