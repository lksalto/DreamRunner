using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool follower;
    public float speed;
    public float[] corectxyz;
    public bool patrol;
    public GameObject sight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (sight.GetComponent<sight>().SeePlayer)
        {
            
            if (follower)
            {
                
                if (patrol) GetComponent<Saw2>().enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, sight.GetComponent<sight>().Player.transform.position + new Vector3(corectxyz[0], corectxyz[1], corectxyz[2]), speed * Time.deltaTime);
            }
        }
        else
        {
            if (follower)
            {
                if (patrol) GetComponent<Saw2>().enabled = true;
            }
        }
    }
}
