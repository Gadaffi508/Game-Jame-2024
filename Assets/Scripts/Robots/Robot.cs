using UnityEngine;
using UnityEngine.AI;

public abstract class Robot : MonoBehaviour
{
    public Transform _target;
    [Range(1,20)]
    public float distance;
    internal NavMeshAgent _agent;
    internal Animator _anim;
    internal bool isClick = false;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float _distance = Vector3.Distance(transform.position,_target.position);

        if (_distance > distance) isClick = false;
        if (Input.GetMouseButtonDown(0)) isClick = true;

        if (isClick is false)
            OnFollow();
        else
            OnClick();

        _anim.SetBool("Walk_Anim", Walked());
    }

    abstract protected void OnClick();
    abstract protected void OnFollow();

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
