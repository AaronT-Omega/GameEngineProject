using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : Subject
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


    private IPlayerStates _stopState, _moveState;

    private PlayerStateContext _playerStateContext;


    [SerializeField] private Rigidbody2D rb2d;
    private BoxCollider2D bc;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

        _playerStateContext = new PlayerStateContext(this);

        
        _moveState = gameObject.AddComponent<PlayerMoveState>();
        _stopState = gameObject.AddComponent<PlayerStopState>();
        

        _playerStateContext.Transition(_stopState);
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
            _playerStateContext.Transition(_moveState);
        }
        else
        {
            _playerStateContext.Transition(_stopState);

        }


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



