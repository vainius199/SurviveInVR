using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;

    
    public Toggle Ar;
    public Toggle Vr;

    public Toggle Easy;
    public Toggle Medium;
    public Toggle Hard;


    void Start()
    {
        
            int Mygun = PlayerPrefs.GetInt("ArGun");
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume"));
        musicSlider.value = PlayerPrefs.GetFloat("Volume");

        if (Mygun == 1)
            {
                Ar.isOn = true;
            }
            else
            {
                Vr.isOn = true;
            }
        
    }

    public void SetVolume (float volume)
    {
     
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void Toogle_Changed(bool newValue)
    {
        Debug.Log(newValue);
        if (newValue)
        {
            audioMixer.SetFloat("volume", -80);
            PlayerPrefs.SetFloat("Volume", -80);
            musicSlider.interactable = false;
        }
        else
        {
            audioMixer.SetFloat("volume", 0);
            PlayerPrefs.SetFloat("Volume", 0);
            musicSlider.interactable = true;
        }
    }


    public void GunOptions()
    {
        if (Ar.isOn)
        {
           // Debug.Log("AR is on");
            PlayerPrefs.SetInt("ArGun", 1);
        }
        else
        {
           // Debug.Log("VR is on");
            PlayerPrefs.SetInt("ArGun", 0);
        }
    
    }

    public void ChangeDifficulty()
    {
        if (Easy.isOn)
        {
             Debug.Log("Easy is on");
            PlayerPrefs.SetInt("Difficulty", 1);

        }
        else if(Medium.isOn)
        {
             Debug.Log("Medium is on");
            PlayerPrefs.SetInt("Difficulty", 2);

        }
        else if (Hard.isOn)
        {
             Debug.Log("Hard is on");
            PlayerPrefs.SetInt("Difficulty", 3);

        }
    }



}
