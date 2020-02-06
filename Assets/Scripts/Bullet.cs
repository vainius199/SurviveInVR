using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damagePerShot = 120;
    EnemyHealth enemyHealth;

   // private void OnCollisionEnter(Collision collision)
         private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
           health.TakeDamage(damagePerShot);
         //  Enemy stuff = collision.gameObject.GetComponent<Enemy>();

           // stuff.TakeDamage(35);
           

            Destroy(this);
        }

        Debug.Log(collision.gameObject.name);
        Destroy(this);
    }


}
