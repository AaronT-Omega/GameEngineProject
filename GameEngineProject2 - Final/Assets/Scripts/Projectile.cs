using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float launchForce;
    [SerializeField] private float disableTime;

    private void OnEnable()
    {
        StartCoroutine(DisableGameObjectWithDelay(disableTime));
        rb.velocity = transform.up * launchForce;
        // Fires the projectile when enabled
    }

    IEnumerator DisableGameObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(disableTime);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall")) // When they touch the player, subtracts 1 HP from the Game Manager and destroys itself
        {
            gameObject.SetActive(false);

        }
    }



    }
