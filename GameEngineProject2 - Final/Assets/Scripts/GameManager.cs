
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    public EnemySpawner badSpawner; //Sets up Enemy Spawning
  
    public int currentScore = 0;
    public int currentHP = 3;
    
    // Sets up score, HP and time

    public float xRange = 16f;
    public float yRange = 9f;
    // Ranges for Random Spawning for enemies

    public float repeatRateScaling;
    // Sets up a varable to reduce spawn times overtime


    [SerializeField] private UI_Manager _uiManager;

    public PlayerController player;
    

    bool isHit;
    // gets access to the Player object to disable later


    private void Update()
    {
        

        badSpawner.randomPos = new Vector3(UnityEngine.Random.Range(-(xRange), xRange), UnityEngine.Random.Range(-(yRange), yRange), 0);
        // Randomly generates the spawn position of the enemies within a predetermined range

        if (badSpawner.repeatRate <= (badSpawner.spawnDelay - 0.5f))
        {
            badSpawner.repeatRate += repeatRateScaling * Time.deltaTime;
        }
        // Creates scaling for the enemies to respawn faster. Will never spawn enemies faster then 1 enemy per 0.5 seconds

        if (currentHP <= 0f)
        {
            _uiManager.GameOver();
            // Calls the Game Over Function when HP is equal to or less then 0
        }
    }
    public override void Notify(Subject subject, IPlayerStates state) // Overides the Notify function
    {

        if (subject)
        {
            if (state == player._hitState)
            {
                currentHP -= 1;
            }
        }
        
    }





}



