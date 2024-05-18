using System;
using UnityEditor;
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

// Custom Editor
#if UNITY_EDITOR
[CustomEditor(typeof(RobotManager)), InitializeOnLoadAttribute]
public class RobotManagerEditor : Editor
{
    RobotManager fpc;
    SerializedObject SerFPC;

    private void OnEnable()
    {
        fpc = (RobotManager)target;
        SerFPC = new SerializedObject(fpc);
    }

    public override void OnInspectorGUI()
    {
        SerFPC.Update();

        EditorGUILayout.Space();
        GUILayout.Label("Robot Plyer Follow Manager ", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 16 });
        GUILayout.Label("Yusuf Arslan", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Normal, fontSize = 12 });
        GUILayout.Label("version 1.0.1", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Normal, fontSize = 12 });
        EditorGUILayout.Space();
    }
}
#endif