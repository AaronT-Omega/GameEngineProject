using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public Transform firePoint;         // Assign an empty GameObject as the fire point



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Instantiate(projectilePrefab,firePoint.position, transform.rotation);

    }
}
