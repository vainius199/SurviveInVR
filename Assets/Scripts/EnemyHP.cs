using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public int startingHealth = 80;
    public int currentHealth;
     public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    Animator Animator;   
    BoxCollider boxCollider;

    bool isDead;
    bool isSinking;


    // Start is called before the first frame update
    void Awake()
    {
       
        Animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
          if (isSinking)
          {
               transform.Translate(Vector3.up * sinkSpeed * Time.deltaTime);
          }
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;

        if (Animator != null)
        {
            
            Animator.Play("TakeDamage", 0, 0.2f);
        }


        if (currentHealth <= 0)
        {
            Death();
        }

    }

    void Death()
    {
        isDead = true;
        isSinking = true;
       
        boxCollider.enabled = false;
                

        if (Animator != null)
        {
            Animator.SetTrigger("Dead");

        }

    }
}
