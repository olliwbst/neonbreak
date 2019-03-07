using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator _animator;
    //get access to animator and close door
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("closed",true);
    }
    //if player or enemy enters collider: open door with animation
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Enemy"))
        {
            _animator.SetBool("open",true);
            _animator.SetBool("closed",false);
        }
    }
    //keep open while object in collider
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Enemy"))
        {
            _animator.SetBool("open",true);
        }
    }
    //close when object leaves
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Enemy"))
        {
            _animator.SetBool("closed",true);
            _animator.SetBool("open",false);
        }
    }
    /*enemy-vision colliders are aranged in way that assures they dont
     hit the ones of the doors, the door only opens for them if they hit 
     it with their "body". this saves code for exception-cases*/
}
