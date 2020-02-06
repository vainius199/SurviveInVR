using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempScript : MonoBehaviour
{
    public float sinkSpeed = 3.5f;
    void Update()
    {
        
           
                gameObject.transform.Translate(Vector3.up * sinkSpeed * Time.deltaTime);
            

        
    }
    // Start is called before the first frame update
    void Start()
    {
        // UnityEngine.XR.XRSettings.enabled = true;
       // StartCoroutine(EnableAR());
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMeniu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

}
