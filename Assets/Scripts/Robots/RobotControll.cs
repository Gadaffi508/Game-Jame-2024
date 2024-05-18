using System;
using UnityEditor;
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

// Custom Editor
#if UNITY_EDITOR
[CustomEditor(typeof(RobotControll)), InitializeOnLoadAttribute]
public class RobotControllEditor : Editor
{
    RobotControll fpc;
    SerializedObject SerFPC;

    private void OnEnable()
    {
        fpc = (RobotControll)target;
        SerFPC = new SerializedObject(fpc);
    }

    public override void OnInspectorGUI()
    {
        SerFPC.Update();

        EditorGUILayout.Space();
        GUILayout.Label("Click on the Robot and let it go. ", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Bold, fontSize = 16 });
        GUILayout.Label("Yusuf Arslan", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Normal, fontSize = 12 });
        GUILayout.Label("version 1.0.1", new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter, fontStyle = FontStyle.Normal, fontSize = 12 });
        EditorGUILayout.Space();
    }
}
#endif
