using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    private PlayerController _controller;
    public MoveRight(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerController.Direction.Right);
    }
}
