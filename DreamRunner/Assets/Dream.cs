using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream : MonoBehaviour
{
    public GameObject[] ativar;
    public bool dreaming;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Drea();
    }
    void Drea()
    {
        if (Input.GetKeyDown("e"))
        {
            Invoke("acti", 0.01f);
            
            dreaming = !dreaming;

        }
    }
    void acti() 
    {
        for (int i = 0; i < ativar.Length; i++)
            {
                
                ativar[i].SetActive(!ativar[i].activeSelf);
            } 
    }
}
