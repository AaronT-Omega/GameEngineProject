using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateContext : MonoBehaviour
{
    public IPlayerStates CurrentState // Get Set
    {
        get; set;
    }

    private readonly PlayerMovement _controller;

    public PlayerStateContext(PlayerMovement controller)
    {
        _controller = controller;
    }

    public void Transition()
    {
        CurrentState.Handle(_controller);
    }
    public void Transition(IPlayerStates state)
    {
        CurrentState = state;
        CurrentState.Handle(_controller);
    }

}
