using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letters : MonoBehaviour
{
    public InputField Name;

    public void OnClicked(Button button)
    {
       
        Name.text  = Name.text + button.name;
    }

    public void Delete()
    {
        string value = Name.text;

        if(value != "")
        {
            value = value.Substring(0, value.Length - 1);
        }
        

        Name.text = value;
    }

    public void Space()
    {
        Name.text = Name.text + " ";
    }
    
}
