using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUp : MonoBehaviour
{

    public GameObject firstEnemys;
    public GameObject secondEnemys;
    public GameObject thirdEnemys;

    GameObject weapon;
    GameObject WaterWeapon;
    GameObject BalloonWeapon;


    Gun_shooting gun_Shooting;
    balloonGun balloonGun;
    WaterGun waterGun;
    

    // Start is called before the first frame update
    public void MoveUpBox()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
    
        if (weapon.activeSelf)
        {
            gun_Shooting = weapon.GetComponent<Gun_shooting>();

            if (gun_Shooting != null)
            {
                gun_Shooting.AddBullets(20);

                if (gameObject)
                {
                    Destroy(gameObject);
                }
            }
        }
        else return;



    }

    public void AddBalloon()
    {
        BalloonWeapon = GameObject.FindGameObjectWithTag("BalloonGun");

        if (BalloonWeapon.activeSelf)
        {

            balloonGun = BalloonWeapon.GetComponent<balloonGun>();

            if (balloonGun != null)
            {
                balloonGun.AddBalloons(1);

                if (gameObject)
                {
                    Destroy(gameObject);
                }
            }
        }
        else return;



    }

    public void AddWater()
    {
        WaterWeapon = GameObject.FindGameObjectWithTag("WaterGun");

        if (WaterWeapon.activeSelf)
        {
            waterGun = WaterWeapon.GetComponent<WaterGun>();

            if (waterGun != null)
            {
                waterGun.AddWater(100);
            }

        }
        else return;



    }




    public void EnableEnemys1()
    {
        firstEnemys.SetActive(true);
    }


    public void EnableEnemys2()
    {
        secondEnemys.SetActive(true);
    }

    public void EnableEnemys3()
    {
        thirdEnemys.SetActive(true);
    }


}
