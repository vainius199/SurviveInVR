using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{

    public GameObject StartUI;
    public GameObject LettersUI;
    public InputField input;
    string Pname;

    public void SaveAName()
    {
         Pname = input.text;

        if (Pname != "")
        {
            PlayerPrefs.SetString("playerName", name);

            LettersUI.SetActive(false);
            StartUI.SetActive(true);
        }

    }
    
    public void Rename()
    {
        LettersUI.SetActive(true);
        StartUI.SetActive(false);

        input.text = Pname;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }

}
