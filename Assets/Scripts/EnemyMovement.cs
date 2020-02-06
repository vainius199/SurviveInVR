using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject box;
  // public Transform getOutPoint;
    Transform loot;
    Transform Point;
    NavMeshAgent nav;
    bool Stole = false;
    Animator Animator;
    Renderer boxRend;
    EnemyHealth enemyHealth;
    public int scoreValue=10;

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Loot")
        {
            Losebox();
            Stole = true;
            Animator.SetTrigger("Stole");
            boxRend.enabled = true;
            enemyHealth.ChangeStoleToTrue();
        }
        if (other.transform.tag == "GetOutPoint")
        {
          
            if (gameObject)
            {
                LosePoints();
                Destroy(gameObject);
            }
            
        }
    }

    public void LosePoints()
    {
        GameManager.score -= scoreValue;
    }

    public void Losebox()
    {
        GameManager.boxes -= 1;
    }


    // Start is called before the first frame update
    void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        boxRend = box.GetComponent<Renderer>();
        Point = GameObject.FindGameObjectWithTag("GetOutPoint").transform;
        loot = GameObject.FindGameObjectWithTag("Loot").transform;
        Animator = GetComponentInChildren<Animator>();

      //  player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth.currentHealth > 0)
        { 

            if (!Stole)
            {
                nav.SetDestination(loot.position);
            }
            else
            {
                nav.SetDestination(Point.position);

            }
        }
        else
        {
            nav.enabled = false;
        }
    }
}
