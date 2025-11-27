using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BadGuySpawner : EnemySpawner
{
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
                SpawnWarning(spawnPos);
                warningFlag = false;
            }
            if (timer < repeatRate)
            {
                timer = spawnDelay;
                warningFlag = true;
                SpawnEnemy(spawnPos);
                
                
                // As the timer decreases, if it's lower then the Repeat Rate which will increment over time, then it will spawn and reset itself
                // back to the spawn delay duration
            }

        }
    }
    public override Enemy SpawnEnemy(Vector3 position) //Spawns the enemy based on the attached prefab
    {
        if (warningFlag)
        {
            for (int i = 0; i < _warningPool.Count; i++)
            {
                if (_warningPool[i].activeInHierarchy == true)
                {
                    _warningPool[i].SetActive(false);
                }
            }
        }



        GameObject createBadguy = SpawnObjectFromPool(_enemyPrefab, _enemyPool, position, Quaternion.identity);
        return createBadguy.GetComponent<Enemy>();
    }
    public override Warning SpawnWarning(Vector3 position) //Spawns the enemy based on the attached prefab
    {
        GameObject createWarning = SpawnObjectFromPool(_warningPrefab, _warningPool, spawnPos, Quaternion.identity);
        return createWarning.GetComponent<Warning>();
    }
    
}
