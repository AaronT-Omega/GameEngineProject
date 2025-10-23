using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float launchForce;
    [SerializeField] private float destroyTime;



    private void Start()
    {
        rb.velocity = transform.up * launchForce;
        // Fires the projectile when created
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
        // After a set amount of time, the projectile disappears
    }

    
}
