
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    public EnemySpawner badSpawner; //Sets up Enemy Spawning
  
    public int currentScore = 0;
    public int currentHP = 3;
    private float timeTrack = 0f;
    // Sets up score, HP and time

    public float xRange = 16f;
    public float yRange = 9f;
    // Ranges for Random Spawning for enemies

    public float repeatRateScaling;
    // Sets up a varable to reduce spawn times overtime



    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthPoints;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    // Access to text boxes to keep track of score,HP, time, and finally manage the Game Over screen

    public GameObject player;
    // gets access to the Player object to disable later


    private void Update()
    {
        UpdateScoreDisplay();
        UpdateHealthDisplay();
        // Checks and Updates Score and Health every frame

        timeTrack += Time.deltaTime; // Increases time
        DisplayTime(timeTrack); //calls the DisplayTime function to show the timer

        badSpawner.randomPos = new Vector3(UnityEngine.Random.Range(-(xRange), xRange), UnityEngine.Random.Range(-(yRange), yRange), 0);
        // Randomly generates the spawn position of the enemies within a predetermined range

        if (badSpawner.repeatRate <= (badSpawner.spawnDelay - 0.5f))
        {
            badSpawner.repeatRate += repeatRateScaling * Time.deltaTime;
        }
        // Creates scaling for the enemies to respawn faster. Will never spawn enemies faster then 1 enemy per 0.5 seconds

        if (currentHP <= 0f)
        {
            GameOver();
            // Calls the Game Over Function when HP is equal to or less then 0
        }
    }


    void UpdateScoreDisplay() // Creates the score to be displayed
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
    void UpdateHealthDisplay() // Creates the HP points to be displayed
    {
        if (healthPoints != null)
        {
            healthPoints.text = "HP: " + currentHP.ToString();
        }
    }

    void DisplayTime(float timeToDisplay) // Creates the timer to be displayed
    {
        timeToDisplay += 1; // To ensure the timer shows 00:00 at the end, not -00:01

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        // Sets it so the minutes and seconds are counted in base 60 properly

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        // Formats the timer text
    }

    void GameOver() // Pauses the game one HP runs out. Also disables the player
    {
 
            Time.timeScale = 0f;
            //Debug.Log("Game Over");
            gameOverText.gameObject.SetActive(true);
            player.gameObject.SetActive(false);

        
    }
}



