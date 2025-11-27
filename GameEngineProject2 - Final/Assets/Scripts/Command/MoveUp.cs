using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : Command
{
    private PlayerController _controller;
    public MoveUp(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerController.Direction.Up);
    }

}
