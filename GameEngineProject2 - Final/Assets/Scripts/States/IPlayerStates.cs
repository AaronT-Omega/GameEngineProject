using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStates
{
void Handle(PlayerMovement controller);
   
}

/*
 * Passes an instance of PlayerMovement in the Handle() method.
 * This allows state classes to access public properties of PlayerMovement
 */

