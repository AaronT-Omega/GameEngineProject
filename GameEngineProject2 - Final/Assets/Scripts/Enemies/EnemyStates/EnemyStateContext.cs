using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateContext : MonoBehaviour
{
    public IEnemyStates CurrentState // Get Set
    {
        get; set;
    }

    private readonly Enemy _controller;

    public EnemyStateContext(Enemy controller)
    {
        _controller = controller;
    }

    public void Transition()
    {
        CurrentState.Handle(_controller);

    }
    public void Transition(IEnemyStates state)
    {
        if (state != CurrentState)
        {
            CurrentState = state;
            CurrentState.Handle(_controller);
        }
    }
}
