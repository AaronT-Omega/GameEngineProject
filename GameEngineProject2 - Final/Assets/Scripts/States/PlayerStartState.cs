using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartState : MonoBehaviour, IPlayerStates
{
    private PlayerMovement _controller;

    public void Handle(PlayerMovement controller)
    {
        if (!_controller)
        {
            _controller = controller;
        }

       


    }

}
