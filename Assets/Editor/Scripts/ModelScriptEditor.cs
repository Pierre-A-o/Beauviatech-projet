using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(ModelModelGO))]
[InitializeOnLoad]
public class ModelScriptEditor : Editor
{

    static ModelModelGO myTarget;

    public void OnEnable()
    {
        myTarget = (ModelModelGO)target;
    }

    static ModelScriptEditor()
    {
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    static void OnSceneGUI( SceneView sceneView)
    {
        if (EditorSceneManager.GetActiveScene().name.Equals("FirstCameraScene"))
        {
            if (Event.current.button == 1)
            {
                if (Event.current.type == EventType.MouseDown)
                {
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("Ajouter Interaction"), false, Callback, 1);
                    menu.ShowAsContext();

                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        for (int i = 0; i < myTarget.interactions.Count; i++)
        {
            EditorGUILayout.LabelField("Intéraction n°" + (i + 1), "");
            EditorGUILayout.LabelField("Position de l'intéraction", "");
            myTarget.interactions[i].position = EditorGUILayout.Vector3Field("", myTarget.interactions[i].position, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
            if (GUILayout.Button("Ajouter un onglet à l'intéraction " + (i + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                myTarget.InstancieNouvelOnglet(i);
            }
        }  
    }

    static void Callback(object o)
    {
        Vector3 test = new Vector3();
        myTarget.InstancieNouvelleInteraction(test);
    }

    public void SetActiveContent(int indexInteraction, int index)
    {
        
    }
}
