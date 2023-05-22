using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : state
{
    public override void OnEnable()
    {
        base.OnEnable();
        movementController.Move(Vector3.zero);
        agent.target = null;
    }
}