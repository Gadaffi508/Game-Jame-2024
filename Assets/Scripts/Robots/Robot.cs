using UnityEditor;
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

#if UNITY_EDITOR
[CustomEditor(typeof(Robot)), InitializeOnLoadAttribute]
public class RobotEditor : Editor
{
    Robot fpc;
    SerializedObject SerFPC;

    private void OnEnable()
    {
        fpc = (Robot)target;
        SerFPC = new SerializedObject(fpc);
    }

    public override void OnInspectorGUI()
    {
        SerFPC.Update();

        EditorGUILayout.Space();
        GUILayout.Label("Robot Manager", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 16 });
        GUILayout.Label("Yusuf Arslan", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Normal, fontSize = 12 });
        GUILayout.Label("version 1.0.1", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Normal, fontSize = 12 });
        EditorGUILayout.Space();
    }
}
#endif
