using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Gun_shooting : MonoBehaviour, IVirtualButtonEventHandler
{

    [Header("Weapon Components")]
    public ParticleSystem muzzleflashParticles;
    public ParticleSystem waterSplash;

    public int bulletsPerMag = 30;
    public int bulletsLeft = 200;
    public int currentBullets;
    public Text ammoText;

    public int shootDamage = 40;
    public GameObject vBtnObj;     
    
    public GameObject shootPoint;

    void Awake()
    {


       
        vBtnObj = GameObject.Find("VButton");
        vBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        currentBullets = bulletsPerMag;
        UpdateAmmoText();
    }

    void OnEnable()
    {
        
        
        UpdateAmmoText();
    }


    void Update()
    {
       


        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            // BalloonGunShoot();
           // WaterGunShoot();
            //waterSplash.Play();
           
           
        }
        else
        {
           // waterSplash.Stop();
        }

        
       


    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
       Shoot();

        
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }


    

     

    public void Shoot()
    {

        if (bulletsLeft <= 0 && currentBullets <= 0) {
            //  return;
            GameManager.score -= 5;
            currentBullets++;
            
        }
   

        if (currentBullets <= 0) Reload();

            RaycastHit hit;
        currentBullets--;
        UpdateAmmoText();

       muzzleflashParticles.Emit(1);
       GetComponent<AudioSource>().Play();
        GetComponent<Animation>().Play();        

        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, 100f, -1,  QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.transform.name);

            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(shootDamage);
               
            }
           
            

        }
        
    }
    

    public void AddBullets(int amount)
    {
        bulletsLeft += amount;
        UpdateAmmoText();
    }

    public void Reload()
    {
        if (bulletsLeft <= 0) return;

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;

    }

    public void UpdateAmmoText()
    {
        ammoText.text = "Ammo: \n" + currentBullets + " / " + bulletsLeft;
    }

}
