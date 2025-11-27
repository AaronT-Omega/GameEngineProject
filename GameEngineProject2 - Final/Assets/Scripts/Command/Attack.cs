using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Command
{
    private PlayerController _controller;
    public Attack(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Attack();
    }

}
