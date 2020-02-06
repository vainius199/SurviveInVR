using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shootPoint;
    public ParticleSystem waterSplash;
    public Text WaterText;
    public int currentWater = 200;
    int test = 0;

    public float fireRate = 0.1f;
    float fireTimer;

   
    void OnEnable()
    {
        UpdateWaterText();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
          
            WaterGunShoot();
           if(currentWater > 1)
            {
                if (!waterSplash.isPlaying)
                {
                    waterSplash.Play();
                }
            }
          
            
        }
        if (Input.GetButtonUp("Fire1"))
        {
            waterSplash.Stop();
        }

        if(fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
    }

    public void WaterGunShoot()
    {
        if (fireTimer < fireRate) return;

        if (currentWater <= 0) return;


        fireTimer = 0.0f;
        RaycastHit hit;
        currentWater--;
        UpdateWaterText();

        if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit, 15f, -1, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.transform.name);

            ////////////////// FOR BOSS HP;
            bossEnemy bossHealth = hit.transform.GetComponent<bossEnemy>();
            if (bossHealth != null)
            {

                // bossHealth.TakeDamage(shootDamage);
             //   currentWater--;
               
                bossHealth.StartCoroutine(bossHealth.DamageOverTimeCoroutine(0.1F, 0.1F));

            }

        }
    }


    public void AddWater(int amount)
    {
        currentWater = amount;
        UpdateWaterText();
    }

    public void UpdateWaterText()
    {
        WaterText.text = "Ammo: \n" + currentWater + " / 100";
    }
}
