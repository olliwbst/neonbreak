using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float camHeight = 20f;

    /*script is on camera and moves it to the players position and up by the specified amount*/
    void Update()
    {
        Vector3 vec = player.transform.position;
        vec.y += camHeight;
        transform.position=vec;
    }
}
