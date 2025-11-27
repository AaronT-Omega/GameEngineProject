using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Transform playerTarget; // Assign the player's Transform in the Inspector
    public float speed = 3f; // Speed value for enemy
    public int enemyHealth;

    public IEnemyStates _eHitState, _eDeathState, _eMoveState;

    public EnemyStateContext _enemyStateContext;


    private void OnEnable()
    {
        //_enemyStateContext = new EnemyStateContext(this);


        //_eHitState = gameObject.AddComponent<EnemyHitState>();
        //_eDeathState = gameObject.AddComponent<EnemyDeathState>();
        //_eMoveState = gameObject.AddComponent<EnemyMoveState>();


        ChangeState(_eMoveState);
    }

    public abstract void Attack();
    //  Attack function to be used edited later

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // When they touch the player, subtracts 1 HP from the Game Manager and destroys itself
        {
            
            gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("Bullet")) // When they touch a bullet, increases score by 1 from the Game Manager and destroys itself
        {
            ChangeState(_eHitState);
            enemyHealth--;

        }

        if (enemyHealth <= 0)
        {
            ChangeState(_eDeathState);
            GameManager.Instance.currentScore += 1;
            gameObject.SetActive(false);
        }
    }
    public void ChangeState(IEnemyStates state)
    {
        _enemyStateContext.Transition(state);
        //Debug.Log(state.ToString());
        //NotifyObservers(this, state);
    }
}
