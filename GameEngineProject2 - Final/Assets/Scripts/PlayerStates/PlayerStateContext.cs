using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateContext : MonoBehaviour
{
    public IPlayerStates CurrentState // Get Set
    {
        get; set;
    }

    private readonly PlayerController _controller;

    public PlayerStateContext(PlayerController controller)
    {
        _controller = controller;
    }

    public void Transition()
    {
        CurrentState.Handle(_controller);
    }
    public void Transition(IPlayerStates state)
    {
        if (state != CurrentState)
        {
            CurrentState = state;
            CurrentState.Handle(_controller);
        }
    }

}
