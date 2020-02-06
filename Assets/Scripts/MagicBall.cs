using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
   
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    public int HealthAttackDamage = 50;
    public int ArrmorAttackDamage = 25;

    void Awake()
    {
      
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
      

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(playerHealth.currentArrmor >= 0)
            {
                playerHealth.TakeArrmorDamage(ArrmorAttackDamage);
            }
            else
            {
                playerHealth.TakeDamage(HealthAttackDamage);
            }
        }
    }

   

}
