using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Pool;

public class PlayerController : Subject
{
    public enum Direction
    {
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
    }

    
    public float speed;
    public float currentSpeed;

    public float horizontalInput;
    public float verticalInput;

    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public Transform firePoint;         // Assign an empty GameObject as the fire point
    [SerializeField] PooledObjects _pooledObjects;


    private GameManager _gameManager;
    private UI_Manager _uiManager;
    private SoundManager _soundManager;


    public IPlayerStates _stopState, _moveState, _hitState, _attackState;

    public PlayerStateContext _playerStateContext;


    [SerializeField] private Rigidbody2D rb2d;
    private BoxCollider2D bc;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();


        _gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        _uiManager = (UI_Manager)FindObjectOfType(typeof(UI_Manager));
        _soundManager = (SoundManager)FindObjectOfType(typeof(SoundManager));

        _playerStateContext = new PlayerStateContext(this);

        
        _moveState = gameObject.AddComponent<PlayerMoveState>();
        _stopState = gameObject.AddComponent<PlayerStopState>();
        _hitState = gameObject.AddComponent<PlayerHitState>();
        _attackState = gameObject.AddComponent<PlayerAttackState>();

        


        ChangeState(_stopState);
    }


    void OnEnable() // Attaches observers when enabled
    {
        if (_gameManager)
            Attach(_gameManager);
        if (_uiManager)
            Attach(_uiManager);
        if (_soundManager)
            Attach(_soundManager);
    }
    void OnDisable() // Detaches observers when disabled
    {
        if (_gameManager)
            Detach(_gameManager);
        if (_uiManager)
            Detach(_uiManager);
        if (_soundManager)
            Detach(_soundManager);
    }


    void FixedUpdate()
    {

        
        /*
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        // Gets the vertical and horizontal inputs

        //Debug.Log(horizontalInput + " " + verticalInput);

        */
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        // Calculate movement direction
        
        if (movement.magnitude > 1f) // Normalize movement vector to prevent faster diagonal movement
        {
            movement.Normalize();
        }

        rb2d.velocity = movement * speed;
        // Apply movement to the object's transform
        // Time.deltaTime ensures consistent speed across different frame rates
        // Makes sure that movement is on a global scale due to how the player is able to rotate

        if (rb2d.velocity.magnitude > 0)
        {
            ChangeState(_moveState);
        }
        else
        {
            ChangeState(_stopState);

        }
    }


    private void ChangeState(IPlayerStates state)
    {
        _playerStateContext.Transition(state);
        //Debug.Log(state.ToString());
        NotifyObservers(this, state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // When they touch the player, subtracts 1 HP from the Game Manager and destroys itself
        {
            ChangeState(_hitState);

        }
    }

    public void Attack()
    {
        ChangeState(_attackState);
      
    
    }
    public void FireProjectile()
    {
        _pooledObjects.GetProjectile(firePoint.position, transform.rotation);

    }
    public void Move(Direction direction)
    {
        
        if (direction == Direction.Left)
            horizontalInput = -1;

        if (direction == Direction.Right)
            horizontalInput = 1;

        if (direction == Direction.Up)
            verticalInput = 1;
        
        if (direction == Direction.Down)
            verticalInput = -1;

    }
    public void StopMove(Direction direction)
    {
        
        if (direction == Direction.Left || direction == Direction.Right)
            horizontalInput = 0;

        if (direction == Direction.Up || direction == Direction.Down)
            verticalInput = 0;

      
    }
}



