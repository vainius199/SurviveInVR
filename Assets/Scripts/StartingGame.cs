using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.XRSettings.enabled = false;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
