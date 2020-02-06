using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextue : MonoBehaviour
{
    public Material material;
   
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.enabled = true;
       // rend.sharedMaterial = material;
       
    }

   public void Change()
    {
        rend.material = material;
    }
}
