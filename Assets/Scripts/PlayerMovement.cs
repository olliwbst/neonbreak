using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //get input on x and y axis
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        /*use x but transform y to z because we are top-down, we basically take the system designed for
         sidescrollers and change an axis to make it work for top-down*/
        rb.velocity = new Vector3(x*speed, 0,y*speed);
    }
}
