using System;
using UnityEngine;
using UnityEngine.AI;

public class RobotManager : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _normalSpeed = 3f;
    [SerializeField] private float _slowSpeed = 1f;
    Animator _anim;
    NavMeshAgent _agent;
    private bool _isSlowed = false;
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
    }private void OnEnable()
    {
        FirstPersonController.timeControl += SlowMotion;
    }

    private void OnDisable()
    {
        FirstPersonController.timeControl -= SlowMotion;
    }


    public void SlowMotion()
    {
        _isSlowed = !_isSlowed; 
        _agent.speed = _isSlowed ? _slowSpeed : _normalSpeed;
        Debug.Log("11");
        if (_isSlowed)
        {
            Invoke("ResetSpeed", 30f); 
        }
    }
    private void ResetSpeed()
    {
        _isSlowed = false;
        _agent.speed = _normalSpeed;
    }
    private void OnEnable()
    {
        FirstPersonController.timeControl += SlowMotion;
    }

    private void OnDisable()
    {
        FirstPersonController.timeControl -= SlowMotion;
    }


    public void SlowMotion()
    {
        _isSlowed = !_isSlowed;
        _agent.speed = _isSlowed ? _slowSpeed : _normalSpeed;
        Debug.Log("11");
        if (_isSlowed)
        {
            Invoke("ResetSpeed", 30f);
        }
    }
    private void ResetSpeed()
    {
        _isSlowed = false;
        _agent.speed = _normalSpeed;
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
