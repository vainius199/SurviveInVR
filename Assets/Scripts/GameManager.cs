using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject[] gameObjects;
    GameObject[] gameObjects2;
    GameObject[] gameObjects3;

    public GameObject Boss;
    public GameObject enemyStealer;
    public GameObject enemyMeleeSkeleton;
    public GameObject enemyRangeSkeleton;
    public GameObject bossFood;

    public  static int boxes;
    public Text Timetext;
    public Text Boxtext;

    GameObject player;  
    PlayerHealth playerHealth;
    public Text Scoretext;
    public GameObject LevelObject;
    public Text LevelIndex;

    public GameObject LevelMission;
    public Text LevelMissionText;
    public static int score;
    int level = 1;
   
    public float Leveltime = 2;
    float time;
    public float spawntime = 5f;

    public Transform[] spawnPointsStealer;
    public Transform[] spawnPointsSkeleton;
    public Transform[] spawnPointsBossFood;

    bool timerEnd = false;

    GameEnd gameEnd;
    bool GameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        gameEnd = GetComponent<GameEnd>();
        score = 0;
        boxes = 20;
        GameOver = false;
        time = Leveltime;
        // StartCoundownTimer();

        Level1();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)
        {
            return;
        }
        
        Boxtext.text = "x " + boxes;

        Scoretext.text = "Score: " + score;

        if (!timerEnd)
        {
            UpdateTimer();
        }

        if (boxes <= 0)
        {
            if (!GameOver)
            {
                GameOver = true;
                PlayerPrefs.SetInt("Won", 0);
                DisableAllEnemys();
                gameEnd.GameOver();
            }

        }

    }

    void SpawnStealer()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPointsStealer.Length);
        

        

        Instantiate(enemyStealer, spawnPointsStealer[spawnPointIndex].position, spawnPointsStealer[spawnPointIndex].rotation);

    }

    void SpawnSkeleton()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPointsSkeleton.Length);

        int SkeletonIndex = Random.Range(0, 100);

        if (SkeletonIndex > 50)
        {
            Instantiate(enemyMeleeSkeleton, spawnPointsSkeleton[spawnPointIndex].position, spawnPointsSkeleton[spawnPointIndex].rotation);
        }
        else
        {
            Instantiate(enemyRangeSkeleton, spawnPointsSkeleton[spawnPointIndex].position, spawnPointsSkeleton[spawnPointIndex].rotation);
        }
        
        

    }

    void SpawnBossFood()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPointsBossFood.Length);

        Instantiate(bossFood, spawnPointsBossFood[spawnPointIndex].position, spawnPointsBossFood[spawnPointIndex].rotation);

    }




    void UpdateTimer()
    {
        if (Timetext != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = Mathf.Floor(time % 60).ToString("00");
           // string fraction = ((time * 100) % 100).ToString("000");
            Timetext.text = "Time: " + minutes + ":" + seconds;

            if (time <= 0 && level == 1)
            {
                time = 60f;
                level = 2;

                Level2();
            }
            if (time <= 0 && level == 2)
            {
                time = 60f;
                level = 3;

                Level3();
            }
            if (time <= 0 && level == 3)
            {
                timerEnd = true;
                EndGame();
            }
            
            

        }
    }


    public void Level1()
    {
        LevelObject.SetActive(true);
        LevelIndex.text = "Level 1";
        StartCoroutine("HideLevelINdex");
             

        LevelMission.SetActive(true);
        LevelMissionText.text = "Protect your boxes from enemies";
        StartCoroutine("HideMission");

        InvokeRepeating("SpawnStealer", spawntime, spawntime);
    }


    public void Level2()
    {
        LevelObject.SetActive(true);
        LevelIndex.text = "Level 2";
        StartCoroutine("HideLevelINdex");


        LevelMission.SetActive(true);
        LevelMissionText.text = "Protect yourself";
        StartCoroutine("HideMission");


        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < gameObjects.Length; i++)
        {
           
            if (gameObjects != null)
            {
                Destroy(gameObjects[i]);
            }
        }
        InvokeRepeating("SpawnSkeleton", spawntime, spawntime);


        //level 2
    }


    public void Level3()
    {
        LevelObject.SetActive(true);
        LevelIndex.text = "Level 3";
        StartCoroutine("HideLevelINdex");

        LevelMission.SetActive(true);
        LevelMissionText.text = "Protect yourself";
        StartCoroutine("HideMission");

        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < gameObjects.Length; i++)
        {
           
            if (gameObjects != null)
            {
                Destroy(gameObjects[i]);
            }

        }


        gameObjects2 = GameObject.FindGameObjectsWithTag("Skeleton");

        for (var i = 0; i < gameObjects2.Length; i++)
        {
            if(gameObjects2 != null)
            {
                Destroy(gameObjects2[i]);
            }
           
        }


        //level 3
    }
   

    public void EndGame()
    {
        LevelMission.SetActive(true);
        LevelMissionText.text = "Defeat final boss";
        StartCoroutine("HideMission");

        LevelObject.SetActive(true);
        LevelIndex.text = "Final Level";
        StartCoroutine("HideLevelINdex");

        Timetext.text = "-- : --";

        CancelInvoke("SpawnSkeleton");
        CancelInvoke("SpawnStealer");

        Boss.SetActive(true);
        InvokeRepeating("SpawnBossFood", spawntime, spawntime);
        
    }

    IEnumerator HideLevelINdex()
    {
        
                yield return new WaitForSeconds(3);

        LevelObject.SetActive(false);

    }


    IEnumerator HideMission()
    {

        yield return new WaitForSeconds(5);

        LevelMission.SetActive(false);

    }

    public void DisableAllEnemys()
    {
        CancelInvoke("SpawnSkeleton");
        CancelInvoke("SpawnStealer");
        CancelInvoke("SpawnBossFood");



        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }


        gameObjects2 = GameObject.FindGameObjectsWithTag("Skeleton");

        for (var i = 0; i < gameObjects2.Length; i++)
        {
            Destroy(gameObjects2[i]);
        }


        gameObjects3 = GameObject.FindGameObjectsWithTag("BossFood");

        for (var i = 0; i < gameObjects3.Length; i++)
        {
            Destroy(gameObjects3[i]);
        }


        Boss.SetActive(false);

    }


}
