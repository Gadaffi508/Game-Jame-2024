using System;
using UnityEngine;
using UnityEngine.AI;

public class RobotControll : Robot
{

    protected override void OnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _agent.stoppingDistance = 0;

                _agent.SetDestination(hit.point);
            }
        }
    }

    protected override void OnFollow()
    {
        //The robot will follow us in its free time.
    }
}
