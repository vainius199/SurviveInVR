using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Test2 : MonoBehaviour
{
    Rigidbody stuff;
    NavMeshAgent nav;
    HingeJoint hg;
    GameObject NewBalloon;
    bool isSinking;

    bool isInAir = false;


    public Material material;
    Renderer rend;


    public GameObject balloonPrefab;
    public GameObject SpawnPoint;
    public float UpSpeed = 2;


    public void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        rend.enabled = true;

    }


    public void Change()
    {
        rend.sharedMaterial = material;
    }



    public void Balloon()       
    {
        if (isInAir) return;

        isInAir = true;
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false;

        NewBalloon = Instantiate(balloonPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        stuff = NewBalloon.transform.GetChild(3).GetComponent<Rigidbody>();
        

        HingeJoint sc = gameObject.AddComponent(typeof(HingeJoint)) as HingeJoint;   
        HingeJoint hg = GetComponent<HingeJoint>();
        hg.connectedBody = stuff;

        Destroy(NewBalloon, 8f);
    }


    IEnumerator Wait()
    {

        yield return new WaitForSeconds(2f);
        isSinking = true;
        Change();
    }


    public void Death()
    {
        

        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;


        StartCoroutine("Wait");

        if (gameObject)
        {
            Destroy(gameObject, 8f);
        }
        

        
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

   

    void Update()
    {
        if (isSinking)
        {
             gameObject.transform.Translate(Vector3.up * UpSpeed * Time.deltaTime);
            
        }
    }

}
