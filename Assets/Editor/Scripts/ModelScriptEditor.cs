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
                    Selection.activeGameObject = GameObject.Find("ModelEditor").gameObject;
                    bool cameraHit = false;
                    GenericMenu menu = new GenericMenu();
                    Vector3 myVector = new Vector3();
                    Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        myVector = hit.point;
                        if (hit.collider.gameObject.name.Equals(myTarget.cameraModel.name))
                        {
                            cameraHit = true;
                        }
                      
                    }
                    if (cameraHit)
                    {
                        
                        menu.AddItem(new GUIContent("Ajouter Interaction"), false, Callback, myVector);
                        menu.ShowAsContext();
                    }
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
            EditorGUILayout.LabelField("Position de l'intéraction n°" + (i + 1), "");
            myTarget.interactions[i].position = EditorGUILayout.Vector3Field("", myTarget.interactions[i].position, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
            GameObject.Find(i + "ZoneClick(Clone)").transform.position = myTarget.interactions[i].position;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Taille de l'intéraction n°" + (i + 1), "");
            myTarget.interactions[i].radius = EditorGUILayout.FloatField(myTarget.interactions[i].radius, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
            float myRad = myTarget.interactions[i].radius;
            GameObject.Find(i + "ZoneClick(Clone)").transform.localScale = new Vector3(myRad, myRad, myRad);
            if (GUILayout.Button("Ajouter un onglet à l'intéraction " + (i + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                myTarget.InstancieNouvelOnglet(i);
            }
            for (int j = 0; j < myTarget.interactions[i].onglets.Count; j++)
            {
                EditorGUILayout.LabelField("Onglet n°" + (j + 1), "");
                if (GUILayout.Button("Edition mise en page de l'onglet " + (j + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    Selection.activeGameObject = GameObject.Find(i + "ContentInteraction(Clone)").transform.Find(j + "TabContent(Clone)").gameObject;
                }
            }
        }

        if (GUI.changed)
        {

            Undo.RecordObject(myTarget, "Saving text");
        }

    }




    static void Callback(object o)
    {
        myTarget.InstancieNouvelleInteraction((Vector3)o);
    }

    public void SetActiveContent(int indexInteraction, int index)
    {
        
    }
}
