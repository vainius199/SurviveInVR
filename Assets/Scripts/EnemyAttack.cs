using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 55f;
    public int attackDamage = 10;


    Vector3 offset = new Vector3(0f, 2f, 0f); 
    Transform playerPosition;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    float timer;
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Awake()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

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


    // Update is called once per frame
    void Update()
    {
        if (gameObject)
        {

            if (nav.enabled)
            {
                nav.SetDestination(playerPosition.position);
                transform.LookAt(playerPosition.position - offset);



            }



            timer += Time.deltaTime;

            if (timer >= timeBetweenAttacks && playerInRange)
            {
                anim.Play("MeleeAttack01", 0, 0);
                // anim.Play("MeleeAttack01", 0, 0);

                timer = 0f;
            }

            if (playerHealth.currentHealth <= 0)
            {
                // anim.SetTrigger("PlayerDead");
            }
        }
    }




    public void Attack()
    {

        if (playerInRange)
        {
            if (playerHealth.currentHealth > 0)
            {

                playerHealth.TakeDamage(attackDamage);

            }
        }
    }
}
