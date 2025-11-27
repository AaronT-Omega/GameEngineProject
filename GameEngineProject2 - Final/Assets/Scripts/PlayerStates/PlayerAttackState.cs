using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : MonoBehaviour, IPlayerStates
{
    private PlayerController _controller;

    public void Handle(PlayerController controller)
    {
        if (!_controller)
        {
            _controller = controller;
        }
        Debug.Log("Player Attacks");
        _controller.FireProjectile();
        SoundManager.PlaySound(SoundType.PlayerAttack);


    }
}
