using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFood : MonoBehaviour
{


    Transform BossPosition;
  //  Animator anim;
   
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Awake()
    {
        BossPosition = GameObject.FindGameObjectWithTag("Boss").transform;      
       
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(BossPosition.position);
    }


   
}
