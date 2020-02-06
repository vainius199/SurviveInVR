using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRange : MonoBehaviour
{



    Vector3 offset = new Vector3(0f, 2f, 0f);

    public GameObject shotPrefab;
    public Transform spawnObject;
    public float shotSpeed = 25f;
    public float followDistance = 10;

    public float timeBetweenAttacks = 5f;
    public int attackDamage = 10;

    Transform playerPosition;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;
    NavMeshAgent nav;
    bool animTrigger = true;
    /*
    public float AttackDistance = 10.0f;
    public float FollowDistance = 20.0f;
    public float DamagePoints = 2.0f;
    
    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;
    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;
    */

    public void Shoot()
    {
            if(playerHealth.currentHealth > 0)
            {
             GameObject gos = Instantiate(shotPrefab, spawnObject.position, spawnObject.rotation) as GameObject;
             gos.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed, ForceMode.Force);

            Destroy(gos, 4f);
            }
           
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    public void Awake()
    {

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

       // nav.Warp(playerPosition.position);

    }



    // Update is called once per frame
    void Update()
    {
       
            if (nav.enabled)
            {
                
                nav.SetDestination(playerPosition.position);


                float dist = Vector3.Distance(player.transform.position, this.transform.position);
                //  bool shoot = false;
                bool follow = (dist < followDistance);



                if (playerInRange)
                {

                    anim.SetTrigger("Attack");
                }


                if (follow && animTrigger)
                {
                    transform.LookAt(playerPosition.position - offset);
                    animTrigger = false;
                    nav.isStopped = false;
                    //  anim.SetTrigger("Found");
                    anim.SetBool("Losted", false);

                }

                if (!follow)
                {
                    animTrigger = true;
                    nav.isStopped = true;
                    // anim.SetTrigger("Lost");
                    // anim.Play("Idle",1,0);
                    anim.SetBool("Losted", true);
                }


            }
        
    }

   

 
}
