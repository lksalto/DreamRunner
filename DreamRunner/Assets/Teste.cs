using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public bool bool1;
    public bool bool2;
    public bool bool3;
    public float float1;
    public float float2;
    public float float3;
    public float transformx;
    public float transformy;
    public float transformz;
    public float transformlocalx;
    public float transformlocaly;
    public float transformlocalz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transformx = transform.eulerAngles.x;
        transformy = transform.eulerAngles.y;
        transformz = transform.eulerAngles.z;
        transformlocalx = transform.localEulerAngles.x;
        transformlocaly = transform.localEulerAngles.y;
        transformlocalz = transform.localEulerAngles.z;
        if (bool1) { transform.Rotate(float1, float2, float3); bool1 = false; }
        if (bool2) { transform.eulerAngles += new Vector3(float1, float2, float3); bool2 = false; }
        if (transformy == 180) bool3 = true; else bool3 = false;
        //if (bool3) { transform.Rotate(float1, float2, float3); }
    }
}
