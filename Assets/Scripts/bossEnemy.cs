using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class bossEnemy : MonoBehaviour
{
    public float startingHealth = 80;
    public float currentHealth;
    public ParticleSystem Smoke;
    public GameObject BossSmoke;
    bool isDead= false;

    Transform playerPosition;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;
    Animator Animator;

    NavMeshAgent nav;
    bool damageDelt = true;

    public Slider bossHP;
    
    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;

        Animator = GetComponent<Animator>();

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.E))
        {
            StartCoroutine(DamageOverTimeCoroutine(0.1F, 0.1F));
        }
        */


        //bossHP.value = currentHealth;
        if (isDead)
        {
            nav.isStopped = true;
        }
        else
        {
            nav.SetDestination(playerPosition.position);
        }

        

        if (playerInRange)
        {
                if (damageDelt)
                {
                    StartCoroutine("FireDamage");
                }
                damageDelt = false;
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }

        if (other.transform.tag == "BossFood")
        {
           
            StartCoroutine(Eat(other.gameObject));
        }

        
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    IEnumerator Eat(GameObject other)
    {

        yield return new WaitForSeconds(1f);
        Destroy(other.gameObject);

        if (currentHealth < 290f)
        {
            currentHealth += 10;
        }

        if(transform.localScale.x < 9f)
        {
            transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            BossSmoke.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        }
       

    }

    IEnumerator FireDamage()
    {

        yield return new WaitForSeconds(0.1f);
        playerHealth.TakeFireDamage(1);
        damageDelt = true;
    }

    

    public IEnumerator DamageOverTimeCoroutine(float damageAmount, float duration)
    {
       

        float amountDamaged = 0;
        float damagePerLoop = damageAmount / duration;
        while (amountDamaged < damageAmount)
        {
            if (!Smoke.isPlaying)
            {
                Smoke.Play();
            }
        
            currentHealth -= damagePerLoop;
            bossHP.value = currentHealth;
            Debug.Log(currentHealth.ToString());
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
        Smoke.Stop();
        if (currentHealth <= 0)
        {
            BossDeath();
            isDead = true;
        }

    }

    public void BossDeath()
    {
        PlayerPrefs.SetInt("Won", 1);
        Animator.SetTrigger("Dead");
        Destroy(gameObject, 4f);
    }
}
