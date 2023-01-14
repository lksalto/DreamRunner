using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject Mario;
    public GameObject Sword1;
    private bool sword1active;
    public GameObject Sword2;
    private bool sword2active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Sword1.activeSelf) 
        {
            Sword2.SetActive(false);
            sword1active = true;
            sword2active = false;
        }
        if (Sword2.activeSelf&&!sword2active) 
        {
            Sword1.SetActive(false); 
            sword2active = true;
            sword1active = false; 
        }
    }
}
