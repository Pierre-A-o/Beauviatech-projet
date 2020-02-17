using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InterviewModelGO))]
public class InterviewScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InterviewModelGO myTarget = (InterviewModelGO)target;
    }
}