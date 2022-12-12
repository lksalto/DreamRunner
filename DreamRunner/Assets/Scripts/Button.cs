using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool pressed;
    private Animator anim;
    public GameObject[] ativar;

    public bool Stayer;
    public bool WillRespawn;
    public float RespawnTime;
    private float timer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(WillRespawn)timer += Time.deltaTime;
        if (timer > RespawnTime) 
        {
            pressed = false;
            anim.SetBool("Pressed", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pressed)
        {
            for(int i = 0; i < ativar.Length; i++) 
            {
                ativar[i].SetActive(!ativar[i].activeSelf);
            }
        pressed = true;
        timer = 0f;
        }
        anim.SetBool("Pressed", true);

        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Stayer)
        {
            for (int i = 0; i < ativar.Length; i++)
            {
                ativar[i].SetActive(!ativar[i].activeSelf);
            }
            pressed = false;
        anim.SetBool("Pressed", false);
        }


    }
}
