using System;
using UnityEngine;
using UnityEngine.AI;

public class RobotManager : MonoBehaviour
{
    [SerializeField] private Transform _target;

    Animator _anim;
    NavMeshAgent _agent;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target is null) return;

        _agent.SetDestination(_target.position);
        

        _anim.SetBool("Walk_Anim", Walked());
    }

    #region Walk Value Get
    private bool Walked()
    {
        if (_agent.velocity.magnitude > 0)
        {
            return true;
        }
        return false;
    }
    #endregion
}
