using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject spawnpoint;
    
    public LookAtPlayer _LookAtPlayer;
    public LookAtMouse _LookAtMouse;
    public CameraShake _CameraShake;
    public Jukebox _Jukebox;

    public List<GameObject> projectiles = new List<GameObject>();
    public float timetofire=0f;
    public float lifetime = 5f;
    public float camshakeduration;
    public float camshakeintensity;
    public bool enablecamshake = false;
    public bool isPlayer = false;
    public bool isEnemy = false;

    private GameObject particleToSpawn;
    
    //check which particle to spawn, depending on the gameobject trying to spawn it
    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            particleToSpawn = projectiles[0];
        }

        if (gameObject.CompareTag("Enemy"))
        {
            particleToSpawn = projectiles[1];
        }
    }

    void Update()
    {
        /*if player shoots, particle is spawned if the left mousebutton is pressed and the shooting is not an cooldown*/
        if (isPlayer)
        {
            if (Input.GetMouseButton(0)&&Time.time>=timetofire)
            {
                timetofire = Time.time + 1 / particleToSpawn.GetComponent<MoveProjectile>().firerate;
                SpawnParticle();
            
                if (enablecamshake) //if camshake is enabled, the coroutine in CameraShake-Script is started
                {
                    StartCoroutine(_CameraShake.Shake(camshakeduration, camshakeintensity));
                }
            }
        }

        /*enemy shoots if it's locking the player and isnt on cooldown*/
        if (isEnemy)
        {
            if (_LookAtPlayer.lockplayer == true&&Time.time>=timetofire)
            {
                timetofire = Time.time + 1 / particleToSpawn.GetComponent<MoveProjectile>().firerate;
                SpawnParticle();
            }
        }
    }

    void SpawnParticle()
    {
        GameObject particle;

        if (spawnpoint != null)
        {
            particle = Instantiate(particleToSpawn, spawnpoint.transform.position, Quaternion.identity);
            if (gameObject.CompareTag("Player"))
            {
                if (_LookAtMouse != null)
                {
                    particle.transform.localRotation = _LookAtMouse.GetRotation(); //particle is rotated towards the mouseposition
                } 
            }

            if (gameObject.CompareTag("Enemy"))
            {
                particle.transform.localRotation = gameObject.transform.rotation; //particle is rotated the same as parent (enemy)
            }
            _Jukebox.PlayGunFx(); //gunsoundeffect is played whenever a particle is spawned
            
            //destroy particle after x seconds in case a collision is missed and it cruises into abyss
            Destroy(particle, lifetime);
        }
        else
        {
            Debug.Log("no spawnpoint set for projectiles");
        }
    }
}
