using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    public GameObject Gun;

    public int startingHealth = 100;
    public int currentHealth;
    public int startingArmor = 100;
    public int currentArrmor;
    public Slider healthSlider;
    public Slider arrmorSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color flashArmorColour = new Color(0f, 0f, 1f, 0.1f);
    CharacterController myCC;

    AudioSource playerAudio;
    VRBluetoothController playerMovement;
    bool isDead;
    bool damaged;
    bool damagedArrmor;

    Gun_shooting gun_Shooting;
    GameObject weapon;

    // Start is called before the first frame update
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        myCC = GetComponent<CharacterController>();
        currentHealth = startingHealth;
        currentArrmor = startingArmor;

        weapon = GameObject.FindGameObjectWithTag("Weapon");
        gun_Shooting = weapon.GetComponent<Gun_shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
       
           gun_Shooting.AddBullets(20);
        }
        


        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;


        if (damagedArrmor)
        {
            damageImage.color = flashArmorColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damagedArrmor = false;

        // myCC.SimpleMove(Vector3.zero);
    }

    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;
        healthSlider.value = currentHealth;

        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }

    public void TakeHealth(int amount)
    {
        

        currentHealth += amount;
        healthSlider.value = currentHealth;

        playerAudio.Play();


    }


    public void TakeArrmor(int amount)
    {


        currentArrmor += amount;
        arrmorSlider.value = currentHealth;

        playerAudio.Play();


    }

    public void TakeFireDamage(int amount)
    {

        currentHealth -= amount;
        healthSlider.value = currentHealth;

       // playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }

    public void TakeArrmorDamage(int amount)
    {
        damagedArrmor = true;

        currentArrmor -= amount;
        arrmorSlider.value = currentArrmor;

        playerAudio.Play();

    

    }

    public void Death()
    {
        PlayerPrefs.SetInt("Won", 0);
        isDead = true;

        myCC.enabled = false;

        Gun.SetActive(false);

    }
}
