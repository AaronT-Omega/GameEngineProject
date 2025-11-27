using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : Enemy
{

    private BoxCollider2D contact;
    public int badGuyHealth = 3;

    private void OnEnable()
    {
        enemyHealth = badGuyHealth;
        _enemyStateContext = new EnemyStateContext(this);


        _eHitState = gameObject.AddComponent<EnemyHitState>();
        _eDeathState = gameObject.AddComponent<EnemyDeathState>();
        _eMoveState = gameObject.AddComponent<EnemyMoveState>();
    }
    private void Update()
    {
        if (playerTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, speed * Time.deltaTime);
            ChangeState(_eMoveState);
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

    
}

