using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuickGame : MonoBehaviour
{

    public GameObject PlaceForPlayer;
    public GameObject playerWeapon;
    public GameObject VRmenu;

    GameObject player;
    PlayerHealth playerHealth;
    CharacterController myCC;
    bool isGameOver = false;
    
    
    public GameObject enemyRange;
    public GameObject enemyMelee;
    public float spawnTime = 2f;
    public Transform[] spawnPoints;
    



     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        myCC = player.GetComponent<CharacterController>();

        InvokeRepeating("Spawn", spawnTime, spawnTime);
     
        
    }

    void Spawn()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyRange, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        /* int SkeletonIndex = Random.Range(0, 100);

         if (SkeletonIndex > 50)
         {

         }
         else
         {         
                Instantiate(enemyMelee, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
         }

         */
    }


    


    void Update()
    {
        

        if (playerHealth.currentHealth <= 0)
        {
            if (!isGameOver)
            {
                isGameOver = true;
                GameOver();
            }
            

        }
    }




    public void GameOver()
    {
        
              
        myCC.enabled = false;      

        playerWeapon.SetActive(false);
        VRmenu.SetActive(false);

        //transform player to somewhere//
        player.transform.position = PlaceForPlayer.transform.position;



    }




    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }


    public void ExitToMenu()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }



}
