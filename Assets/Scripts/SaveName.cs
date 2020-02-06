using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public GameObject StartUI;
    public GameObject LettersUI;
    public InputField input;

    public void SaveAName()
    {
        string name = input.text;

        if(name != "")
        {
            PlayerPrefs.SetString("playerName", name);
            
            LettersUI.SetActive(false);
            StartUI.SetActive(true);
        }

    }
}
