using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : MonoBehaviour, IEnemyStates
{
    private Enemy _controller;

    public void Handle(Enemy controller)
    {
        if (!_controller)
        {
            _controller = controller;
        }
        Debug.Log("Enemy Move!");



    }
}
