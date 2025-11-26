using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuySpawner : EnemySpawner
{
    public GameObject badguyPrefab;
    public GameObject badguyWarning;
    Vector3 spawnPos;
    private bool warningFlag = true;
    private void Start()
    {
        timer = spawnDelay + repeatRate;
        // Sets the timer with the Spawn Delay and added Repeat Rate so the spawn delay lasts the full duration
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer < repeatRate + 2)
        {
            if (warningFlag)
            {
                spawnPos = randomPos;
                GameObject createWarning = Instantiate(badguyWarning, spawnPos, Quaternion.identity);
                warningFlag = false;
            }
            if (timer < repeatRate)
            {
                Debug.Log(repeatRate + " " + timer);
                timer = spawnDelay;
                SpawnEnemy(spawnPos);
                warningFlag = true;
                
                // As the timer decreases, if it's lower then the Repeat Rate which will increment over time, then it will spawn and reset itself
                // back to the spawn delay duration
            }

        }
    }
    public override Enemy SpawnEnemy(Vector3 position) //Spawns the enemy based on the attached prefab
    {

        GameObject createBadguy = Instantiate(badguyPrefab, position, Quaternion.identity);
        return createBadguy.GetComponent<Enemy>();
    }
}
