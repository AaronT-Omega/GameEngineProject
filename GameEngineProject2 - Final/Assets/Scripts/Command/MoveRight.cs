using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    private PlayerMovement _controller;
    public MoveRight(PlayerMovement controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerMovement.Direction.Right);
    }
}
