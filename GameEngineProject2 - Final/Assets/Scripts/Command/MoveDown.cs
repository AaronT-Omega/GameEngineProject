using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : Command
{
    private PlayerMovement _controller;
    public MoveDown(PlayerMovement controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerMovement.Direction.Down);
    }
}
