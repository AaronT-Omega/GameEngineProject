using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : Command
{
    private PlayerMovement _controller;
    public MoveUp(PlayerMovement controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerMovement.Direction.Up);
    }

}
