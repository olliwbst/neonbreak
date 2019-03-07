using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public float firerate;
    public GameObject muzzlepref;
    public GameObject hitpref;

    void Start()
    {
        //muzzle is created and destroyed based on eighter it's own duration or the one of its child
        var muzzle = Instantiate(muzzlepref, transform.position, Quaternion.identity);
        muzzle.transform.forward = gameObject.transform.forward;
        var delMuzzle = muzzle.GetComponent<ParticleSystem>();
        if (delMuzzle != null)
        {
            Destroy(muzzle,delMuzzle.main.duration);
        }
        else
        {
            var delChild = muzzle.transform.GetChild(0).GetComponent<ParticleSystem>();
            Destroy(muzzle,delChild.main.duration);
        }
    }

    void Update()
    {
        //projectile is moved forward a set amount each frame
        transform.position += transform.forward*(speed*Time.deltaTime);
        //transform.up can be used for flares etc if i got time

        /*raycast to check if there will be a collision right in front of projectile
        to trigger the oncollision right away to never miss it*/
        RaycastHit hit;
        Ray ray=new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, speed/50))
        {
            Collision(hit);
        }
    }
    /*custom collision-detection method based on the raycasts above, more accurate than standart
     OnCollisionEnter because it's not dependent on framerate-timing*/
    void Collision(RaycastHit rayhit)
    {
        speed = 0;

        Quaternion rot = Quaternion.FromToRotation(Vector3.up, rayhit.point);
        Vector3 pos = rayhit.point;

        var hit = Instantiate(hitpref,pos,rot); //hit-fx is spawned on hitpoint
        //destroy the hit-fx
        var delHit = hit.GetComponent<ParticleSystem>();
        if (delHit != null)
        {
            Destroy(hit,delHit.main.duration);
        }
        else
        {
            var delChild = hit.transform.GetChild(0).GetComponent<ParticleSystem>();
            Destroy(hit,delChild.main.duration);
        }
        
        Destroy(gameObject,.1f); //wait .1f with destruction of projectile to give other objects more time to trigger actions
    }
}
