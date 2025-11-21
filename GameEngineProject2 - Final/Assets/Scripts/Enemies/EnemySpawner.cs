using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{

    public float spawnDelay = 5.0f;
    public float repeatRate = 5.0f;
    // Sets up Spawn Delay and Repeat Rate
    public float timer;
    // Sets up timer to keep track of when the enemy spawns
    public Vector3 randomPos;
    // Sets up Random Position for the Game Manager to alter during the gameplay


    public abstract Enemy SpawnEnemy();
    // Funtion to spawn enemies meant to be edited later

}
