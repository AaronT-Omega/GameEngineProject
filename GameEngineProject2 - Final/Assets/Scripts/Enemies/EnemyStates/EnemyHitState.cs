using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : MonoBehaviour, IEnemyStates
{
    private Enemy _controller;

    public void Handle(Enemy controller)
    {
        if (!_controller)
        {
            _controller = controller;
        }
        Debug.Log("Enemy Hit!");
        SoundManager.PlaySound(SoundType.EnemyHit);


    }
}
