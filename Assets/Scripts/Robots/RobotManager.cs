using System;
using UnityEngine;
using UnityEngine.AI;

public class RobotManager : Robot
{
    protected override void OnClick()
    {
        //
    }

    protected override void OnFollow()
    {
        if (_target is null) return;

        _agent.SetDestination(_target.position);

        _agent.stoppingDistance = 5;
    }
}
