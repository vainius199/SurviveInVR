using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MobileVRInventory;
using UnityEngine.UI;

public class NewTest : MonoBehaviour
{

    public GameObject gun;
    public GameObject WaterGun;
    public GameObject BalloonGun;

    public VRInventory VRInventory;
    public Slider sliderHealth;
    public Slider sliderArmor;

    GameObject gunAmmo;    
    Gun_shooting gunShooting;

    private void Start()
    {
      //  player = GameObject.FindGameObjectWithTag("Player");
       // playerHealth = player.GetComponent<PlayerHealth>();
    }

    public void OnItemSelected(InventoryItemStack stack)
    {
        if(stack.item.name == "HealthBox")
        {
            VRInventory.RemoveItem("HealthBox", 1, stack);
            sliderHealth.value = sliderHealth.value + 15;
           
        }
        if (stack.item.name == "Armor")
        {
            VRInventory.RemoveItem("Armor", 1, stack);
            sliderHealth.value = sliderArmor.value + 15;

        }
        if (stack.item.name == "Ammo")
        {
             gunShooting = gunAmmo.GetComponent<Gun_shooting>();
            VRInventory.RemoveItem("Ammo", 1, stack);
            gunShooting.AddBullets(20);

        }
        if (stack.item.name == "WaterGun")
        {
            WaterGun.SetActive(true);
            gun.SetActive(false);
            BalloonGun.SetActive(false);

        }
        if (stack.item.name == "BalloonGun")
        {
            WaterGun.SetActive(false);
            gun.SetActive(false);
            BalloonGun.SetActive(true);

        }
        if (stack.item.name == "Gun")
        {
            WaterGun.SetActive(false);
            gun.SetActive(true);
            BalloonGun.SetActive(false);

        }

    }

    public void OnItemPickedUp(VRInventory.InventoryItemPickupResult result)
    {
        
    }
    
  }



