using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjects : MonoBehaviour
{
    [Header("Objects to Pool")]
    [SerializeField] GameObject _prefabObject;


    int _totalSpawn = 0;
    int _totalPooled = 0;

    List<GameObject> _pool = new List<GameObject>();


    public GameObject GetProjectile(Vector3 location, Quaternion rotation)
    {
        return SpawnObjectFromPool(_prefabObject, _pool, location, rotation);
    }

    

    private GameObject SpawnObjectFromPool (GameObject objPrefab, List<GameObject> pool, Vector3 location, Quaternion rotation)
    {
        Debug.Log($"Total Spawn: {_totalSpawn} $Total Pooled: {_totalPooled}");

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
        GameObject obj = Instantiate(objPrefab, location, rotation);
        pool.Add(obj);
        _totalSpawn++;
        return obj;
    }

}
