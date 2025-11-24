using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MonoBehaviour, IPlayerStates
{
    private PlayerMovement _controller;

    public void Handle(PlayerMovement controller)
    {
        if (!_controller)
        {
            _controller = controller;
        }

        //Debug.Log("Moving");

    }

    void Update()
    {
        if (_controller)
        {
            Vector3 movement = new Vector3(_controller.horizontalInput, _controller.verticalInput, 0);
            // Calculate movement direction

            if (movement.magnitude > 1f) // Normalize movement vector to prevent faster diagonal movement
            {
                movement.Normalize();
            }


            _controller.transform.Translate(movement * _controller.speed * Time.deltaTime, Space.World);
        }

    }
}

