using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{

    const string privateCode = "sLr3H-ipXECcqHMZqxYWmQ1j8jMIFJaE2Lwu-XwAe4ww";
    const string publicCode = "5dcac6c1b5622e683c0385d2";
    const string webURL = "http://dreamlo.com/lb/";

    string playerName;
    int score;
    int WinLost;
    public GameObject PlayerUI;

    public GameObject PlaceForPlayer;
    public GameObject playerWeapon;
    public GameObject VRmenu;

    public Text nameText;
    public Text scoreText;
    public Text WonLostText;

    GameObject player;
    PlayerHealth playerHealth;
    CharacterController myCC;
    GameManager gameManager;

    int delete = 1;

    void Start()
    {

        

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        myCC = player.GetComponent<CharacterController>();
        gameManager = GetComponent<GameManager>();

       

    }


    void Update()
    {
        if (playerHealth.currentHealth <=0)
        {
            GameOver();
            
        }
    }




    public void GameOver()
    {

        PlayerUI.SetActive(false);
        myCC.enabled = false;       
        gameManager.DisableAllEnemys();      
        playerWeapon.SetActive(false);
        VRmenu.SetActive(false);

        //transform player to somewhere//
        player.transform.position = PlaceForPlayer.transform.position;


        playerName = PlayerPrefs.GetString("playerName");
        score = GameManager.score;
        WinLost = PlayerPrefs.GetInt("Won");

        if (WinLost == 1)
        {
            WonLostText.text = "You Won!";
        }
        else
        {
            WonLostText.text = "You Lost!";
        }


        nameText.text = "Name: " + playerName;
        scoreText.text = "Score: " + score;

        //Check if player won or lost

        //WonLostText.text = "You: " + "Won/" + "Lost";

        AddNewHighscore(playerName, score);

        
    }



    public void AddNewHighscore(string username, int score)
    {
       StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        yield return new WaitForSeconds(30);
               
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
