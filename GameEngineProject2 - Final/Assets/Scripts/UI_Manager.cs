using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : Singleton<UI_Manager>
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthPoints;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    private Vector3 _initialPosition;
    private float _shakeMagnitude = 0.2f;


    private float timeTrack = 0f;
    // Access to text boxes to keep track of score,HP, time, and finally manage the Game Over screen


    [SerializeField] private PlayerController player;


    private void Update()
    {
        UpdateScoreDisplay();
        UpdateHealthDisplay();
        // Checks and Updates Score and Health every frame

        timeTrack += Time.deltaTime; // Increases time
        DisplayTime(timeTrack); //calls the DisplayTime function to show the timer


    }
        void UpdateScoreDisplay() // Creates the score to be displayed
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.currentScore.ToString();
        }
    }
    void UpdateHealthDisplay() // Creates the HP points to be displayed
    {
        if (healthPoints != null)
        {
            healthPoints.text = "HP: " + GameManager.Instance.currentHP.ToString();
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

    public void GameOver() // Pauses the game one HP runs out. Also disables the player
    {

        Time.timeScale = 0f;
        //Debug.Log("Game Over");
        gameOverText.gameObject.SetActive(true);
        GameManager.Instance.player.gameObject.SetActive(false);


    }

    public override void Notify(Subject subject, IPlayerStates state) // Overides the Notify function
    {

        if (player)
        {
            if ((state == player._hitState))
            {
                gameObject.transform.localPosition = _initialPosition + (Random.insideUnitSphere * _shakeMagnitude);
            }
            else
            {
                gameObject.transform.localPosition = _initialPosition;
            }

        }

    }


    
}
