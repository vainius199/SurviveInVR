using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ItemUse : MonoBehaviour
{
    public Slider musicSlider;
    public AudioMixer audioMixer;
  
    public GameObject Gun;
    public GameObject BalloonGun;
    public GameObject WaterGun;

    

    public void MainWeapon()
    {
        Gun.SetActive(true);
        WaterGun.SetActive(false);
        BalloonGun.SetActive(false);
    }

    public void WaterWeapon()
    {
        Gun.SetActive(false);
        WaterGun.SetActive(true);
        BalloonGun.SetActive(false);
    }

    public void BallonWeapon()
    {
        Gun.SetActive(false);
        WaterGun.SetActive(false);
        BalloonGun.SetActive(true);
    }


    public void GetPoints()
    {
        GameManager.score += 10;
    }

    void Start()
    {

        
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume"));
        musicSlider.value = PlayerPrefs.GetFloat("Volume");


    }

    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }

}
