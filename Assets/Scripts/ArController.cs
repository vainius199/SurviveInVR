using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArController : MonoBehaviour
{
   

    private Transform vrCamera;
    public float moveSpeed = 0.11f;
    public GameObject player;
    CharacterController myCC;  
    float walking;

    bool isWalking = true;

    void Start()
    {
         myCC = player.GetComponent<CharacterController>();
        vrCamera = Camera.main.transform;
    }



    // Update is called once per frame
    void Update()
    {
        
     
        Vector3 angle = transform.eulerAngles;
        float x = angle.x;
        float y = angle.y;
        float z = angle.z;

        if (Vector3.Dot(transform.up, Vector3.up) >= 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = angle.x - 360f;
            }
        }
        if (Vector3.Dot(transform.up, Vector3.up) < 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = 180 - angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = 180 - angle.x;
            }
        }

        if (angle.y > 180)
        {
            y = angle.y - 360f;
        }

        if (angle.z > 180)
        {
            z = angle.z - 360f;
        }

        
        //Debug.Log(angle + " :::: " + Mathf.Round(x) + " , " + Mathf.Round(y) + " , " + Mathf.Round(z));

        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
               

        if (Mathf.Round(x) >= -85)
        {
            Debug.Log("priekis");
            if (Mathf.Round(x) >= -60 )
            {
              //  if (Mathf.Round(y) <= 15 && Mathf.Round(y) >= -15)
              //  {
                    isWalking = true;
                   Debug.Log("WalkingFoward");
                    myCC.SimpleMove(forward * moveSpeed);
            //    }
                    
            }

            //Jei žiūri tiesiai
        //  else if (eulerAngY <= 46 || eulerAngY >= 315)
         //   {
             // Debug.Log("Looking forward");
             else if (Mathf.Round(z) >= 25)
                {
                    isWalking = true;
                    Debug.Log("Walking To Left NR1");
                    myCC.SimpleMove(vrCamera.TransformDirection(Vector3.left) * moveSpeed);
                }

                else if (Mathf.Round(z) <= -25)
                {
                    isWalking = true;
                   Debug.Log("Walking To Right NR1");
                    myCC.SimpleMove(vrCamera.TransformDirection(Vector3.right) * moveSpeed);
                }


        }
        
     else if (Mathf.Round(x) <= -95)
        {
            Debug.Log("galas");
           
            if (Mathf.Round(x) <= -100)
            {
              //  if (Mathf.Round(y) <= -165 || Mathf.Round(y) >= 165)
              //  {
                    isWalking = true;
                    Debug.Log("WalkingBack");
                    myCC.SimpleMove(vrCamera.TransformDirection(Vector3.back) * moveSpeed);
               // }
                    
            }
            
        }
        else 
        {
            if (isWalking)
            {
                
                isWalking = false;
                myCC.SimpleMove(Vector3.zero);
                Debug.Log("ZERO");
             
            }
           

        }
             
    }
}
