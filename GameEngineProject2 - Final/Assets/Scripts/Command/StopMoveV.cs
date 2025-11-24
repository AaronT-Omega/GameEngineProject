using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveV :     Command
{
    // Start is called before the first frame update
    private PlayerMovement _controller;
    public StopMoveV(PlayerMovement controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.StopMove(PlayerMovement.Direction.Up);
    }
}
