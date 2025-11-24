using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command
{
    // Start is called before the first frame update
    private PlayerMovement _controller;
    public MoveLeft(PlayerMovement controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerMovement.Direction.Left);
    }

    void Update()
    {
        Execute();
    }
}
