using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(player.position.x, this.transform.position.y, this.transform.position.z);
    }
}
