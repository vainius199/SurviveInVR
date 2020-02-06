using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sinking : MonoBehaviour
{
   
    public Material material;
     Renderer rend;
   public int scoreValue = 10;

    public GameObject box;
    Renderer boxRend;

    Animator Animator;
    BoxCollider boxCollider;
    bool isSinking;
    public float sinkSpeed = 1f;

    public void Awake()
    {
        rend = GetComponentInChildren<Renderer>();
        rend.enabled = true;
       
    }

    public void ScorePoints()
    {
        GameManager.score += scoreValue;
    }

    public void Change()
    {
        rend.sharedMaterial = material;
    }

    public void StartSinking()
    {
        ScorePoints();

        boxRend = box.GetComponent<Renderer>();
        boxRend.enabled = false;
        GetComponentInParent<NavMeshAgent>().enabled = false;
        GetComponentInParent<Rigidbody>().isKinematic = true;

        StartCoroutine("Wait");
        

        if (gameObject)
        {
            Destroy(transform.parent.gameObject, 6f);
        }
    }

   
    void Update()
    {
        if (isSinking)
        {
            transform.parent.gameObject.transform.Translate(Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    IEnumerator Wait()
    {       
           
            yield return new WaitForSeconds(1);
             isSinking = true;
        Change();
    }


}
