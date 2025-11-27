using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveV :     Command
{
    // Start is called before the first frame update
    private PlayerController _controller;
    public StopMoveV(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.StopMove(PlayerController.Direction.Up);
    }
}
