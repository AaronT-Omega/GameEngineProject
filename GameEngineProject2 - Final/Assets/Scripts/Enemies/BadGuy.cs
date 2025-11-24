using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : Enemy
{

    private BoxCollider2D contact;


    private void Update()
    {
        if (playerTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
            // Tracks down the player's position every frame

            if (transform.position.magnitude > 1f) // Normalize movement vector to prevent faster diagonal movement
            {
                transform.position.Normalize();
            }
        }

        Attack();


    }

    public override void Attack()
    {
        if (!playerTarget)
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
            // Searches for the player with the Player tag
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // When they touch the player, subtracts 1 HP from the Game Manager and destroys itself
        {
            GameManager.Instance.currentHP -= 1;
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("Bullet")) // When they touch a bullet, increases score by 1 from the Game Manager and destroys itself
        {
            GameManager.Instance.currentScore += 1;
            Destroy(gameObject);

        }
    }
}

