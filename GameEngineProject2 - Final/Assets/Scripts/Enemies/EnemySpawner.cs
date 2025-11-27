using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{

    public float spawnDelay = 5.0f;
    public float repeatRate = 5.0f;
    public float warningDelay = 2.0f;

    public Transform parentObject;


    [SerializeField] public GameObject _enemyPrefab;
    [SerializeField] public GameObject _warningPrefab;

    int _totalSpawn = 0;
    int _totalPooled = 0;

    public List<GameObject> _enemyPool = new List<GameObject>();
    public List<GameObject> _warningPool = new List<GameObject>();

    // Sets up Spawn Delay and Repeat Rate
    public float timer;
    // Sets up timer to keep track of when the enemy spawns
    public Vector3 randomPos;
    // Sets up Random Position for the Game Manager to alter during the gameplay


    public abstract Enemy SpawnEnemy(Vector3 position);
    // Funtion to spawn enemies meant to be edited later

    public abstract Warning SpawnWarning(Vector3 position);







    public GameObject SpawnObjectFromPool(GameObject objPrefab, List<GameObject> pool, Vector3 location, Quaternion rotation)
    {
        //Debug.Log($"Total Spawn: {_totalSpawn} $Total Pooled: {_totalPooled}");

        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].transform.position = location;
                pool[i].transform.rotation = rotation;
                pool[i].SetActive(true);
                _totalPooled++;
                return pool[i];
            }


        }
        GameObject obj = Instantiate(objPrefab, location, rotation, parentObject);
        pool.Add(obj);
        _totalSpawn++;
        return obj;
    }

}
