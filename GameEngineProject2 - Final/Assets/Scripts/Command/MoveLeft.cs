using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command
{
    // Start is called before the first frame update
    private PlayerController _controller;
    public MoveLeft(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Execute()
    {
        _controller.Move(PlayerController.Direction.Left);
    }

    void Update()
    {
        Execute();
    }
}
