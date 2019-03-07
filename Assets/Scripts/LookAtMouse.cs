using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Camera cam;
    
    void FixedUpdate()
    {
        //get a v3 of the mouseposition and transform it from screenspace (a v2) to worldspace from cameraperspective
        Vector3 mousePos = new Vector3(Input.mousePosition.x,Input.mousePosition.y,1f);
        Vector3 lookPos = cam.ScreenToWorldPoint(mousePos);
        //subtract playerposition from this v3
        lookPos = lookPos - transform.position;
        //calculate the angle for playerrotation towards this vector
        float angle = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis((-angle+90), Vector3.up);
    }
    
    //return rotation to use it in projectile
    public Quaternion GetRotation()
    {
        return transform.rotation;
    }
    
    //return playerposition to use in enemy behaviour
    public Vector3 GetPlayerPosition()
    {
        return transform.localPosition;
    }
}
