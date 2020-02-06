using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class balloonGun : MonoBehaviour
{
    public GameObject shootPoint;
    public Text ammoText;
    public int currentBalloons = 3;

   

    void OnEnable()
    {
        UpdateBalloonText();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            BalloonGunShoot();
            
        }
    }

    public void BalloonGunShoot()
    {
        // if (currentBullets <= 0) return;
        if (currentBalloons <= 0) return;

        RaycastHit hit;
        //  currentBullets--;
        //  UpdateAmmoText();

        //   muzzleflashParticles.Emit(1);
        //   GetComponent<AudioSource>().Play();
        //   GetComponent<Animation>().Play();        

        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, 100f, -1, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.transform.name);

            Test2 test2 = hit.transform.GetComponent<Test2>();
            if (test2 != null)
            {

                if (hit.transform.tag == "Skeleton")
                {
                    currentBalloons--;
                    UpdateBalloonText();
                    test2.Balloon();
                }
            }


        }
    }

    public void AddBalloons(int amount)
    {
        currentBalloons += amount;
        UpdateBalloonText();
    }

    public void UpdateBalloonText()
    {
        ammoText.text = "Ammo: \n" + currentBalloons;
    }

}
