using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneGUIGenericMenu : Editor
{
    /*public GameObject test;
    static SceneGUIGenericMenu ()
    {
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    static void OnSceneGUI (SceneView sceneView)
    {
        Debug.Log(sceneView.name);
        if (Event.current.button == 1)
        {
            if(Event.current.type == EventType.MouseDown)
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Ajouter Interaction"), false, Callback, 1);
                menu.ShowAsContext();

            }
        }
    }

    static void Callback (object obj)
    {
        Debug.Log(obj);
    }*/
}
