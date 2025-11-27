using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStates
{

    void Handle(Enemy controller);





}

/*
 * Passes an instance of PlayerController in the Handle() method.
 * This allows state classes to access public properties of PlayerController
 */
