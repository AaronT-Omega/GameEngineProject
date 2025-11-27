using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopState : MonoBehaviour, IPlayerStates
{
    private PlayerController _controller;

    public void Handle(PlayerController controller)
    {
        if (!_controller)
        {
            _controller = controller;
        }
        Debug.Log("Player Stopped");
        


    }

    
}
