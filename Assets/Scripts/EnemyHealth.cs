using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyHealth : MonoBehaviour
{

    public GameObject MainBox;

    public int startingHealth = 80;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    Animator Animator;
    Animator Animator2;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    ItemDrop itemDrop;
    bool DidStole = false;
    bool isDead;
  


    // Start is called before the first frame update
    void Awake()
    {
       

       nav = GetComponent<NavMeshAgent>();

        Animator = GetComponentInChildren<Animator>();
        if(gameObject.tag == "Skeleton")
        {
            itemDrop = GetComponent<ItemDrop>();
            Animator2 = GetComponent<Animator>();
        }
        boxCollider = GetComponent<BoxCollider>();
        currentHealth = startingHealth;

    }


    public void StopMovement()
    {
        if (nav.enabled)
        {
            nav.isStopped = true;
        }

    }

    public void ResumeMovement()
    {
        if (nav.enabled)
        {
            nav.isStopped = false;
        }

    }


    public void TakeDamage( int amount)
    {
        if (isDead)
        {
            return;
        }

        if (gameObject.tag == "Skeleton")
        {
            Animator2.Play("TakeDamage", 0, 0.1f);
        }
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Death();
        }

    }

    public void ScorePoints()
    {
        GameManager.score += scoreValue;
    }

    void Death()
    {
        isDead = true;
       
        
        boxCollider.enabled = false;

        if (gameObject.tag == "Skeleton")
        {
           
            Animator2.SetTrigger("Dead");
            itemDrop.DropItem();
            


        }
        else if (gameObject.tag == "Enemy")
        {
            Animator.SetTrigger("Dead");
            ScorePoints();

            if (DidStole)
            {
                StartCoroutine("Drop");
            }
           
        }
    
       
    }


    public void ChangeStoleToTrue()
    {
        DidStole = true;
    }

    


    IEnumerator Drop()
    {
        yield return new WaitForSeconds(2.5f);
                       
     Instantiate(MainBox, transform.position, Quaternion.identity);
                         
        
    }



}
