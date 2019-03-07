using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public LookAtMouse lookatmouse;
    public bool lockplayer = false; //bool that combines the looking at and shooting at player, both are activated if this is true
    
    /*gets the position of the player and makes the enemy ,in this case, look at it.
     conversion of transform.forward to right because the enemy prefab is rotated somehow
     and this fix was easier than changing the prefab again*/
    void FixedUpdate()
    {
        if (lockplayer)
        {
            transform.forward = transform.right;
            transform.LookAt(lookatmouse.GetPlayerPosition());
        }
    }
}
