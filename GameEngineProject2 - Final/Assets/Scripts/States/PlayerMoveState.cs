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

        Debug.Log("Moving");

    }   

    
}

