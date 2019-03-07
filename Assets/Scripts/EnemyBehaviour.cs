using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    /*I'm a clever Robot Beep-Boop
    ..............
    .  *      *  .
    [.      '     .]
    .            .
    .     ~~     .
    ..............
    */
    /*enemy behaviour is handled here and right now in 3 states: waiting for player interaction, patroling points
     in the level or chasing the player while shooting at him*/
    public GameObject player;
    public LookAtPlayer _LookAtPlayer;
    public bool ChasePlayer = false;
    public bool PatrolArea = false;
    public Transform[] points;

    private NavMeshAgent agent;
    private int destPoint = 0;

    private void Start()
    {
        /*pathfinding is handled with unity's navmesh system where the level is baked into a walkable surface
         that the agents (here enemys) can then automatically navigate on if provided with a targetpoint on it*/
        agent = GetComponent<NavMeshAgent>(); 

        if (PatrolArea) //desired states can be adjusted in the editor using booleans
        {
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            // agent.autoBraking = false; ,could be enabled to stop agents from slowing down before reaching point

            GotoNextPoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ChasePlayer)
        {
            /*if state==chase, the agents targetpoint is the players position, could be altered so the enemy stops
             chasing if a condition is met but for now they dont stop chasing. ever.*/
            agent.destination = player.transform.position;
        }

        if (PatrolArea)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return;
        }
        
        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    //check if player enters collider or shoots it and begin chasing if true
    //also moves faster in chase which could be moved to a public float for balancing later
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")||other.CompareTag(("ProjectileP")))
        {
            ChasePlayer = true;
            agent.speed = 10;
            _LookAtPlayer.lockplayer = true;
        }
    }
}
