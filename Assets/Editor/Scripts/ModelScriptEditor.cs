using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        if (EditorSceneManager.GetActiveScene().name.Equals("SceneTestRegroupement"))
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

        foreach(Interaction i in myTarget.interactions.ToList())
        {
            DrawUILineFat(Color.black);
            int indexInteraction = myTarget.interactions.IndexOf(i);
            EditorGUILayout.LabelField("Intéraction n°" + (indexInteraction + 1), "");
            EditorGUILayout.LabelField("Position de l'intéraction n°" + (indexInteraction+ 1), "");
            myTarget.interactions[indexInteraction].position = EditorGUILayout.Vector3Field("", myTarget.interactions[indexInteraction].position, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
            GameObject.Find(i.id + "ZoneClick(Clone)").transform.position = myTarget.interactions[indexInteraction].position;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Taille de l'intéraction n°" + (indexInteraction+ 1), "");
            myTarget.interactions[indexInteraction].radius = EditorGUILayout.FloatField(myTarget.interactions[indexInteraction].radius, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
            float myRad = myTarget.interactions[indexInteraction].radius;
            GameObject.Find(i.id + "ZoneClick(Clone)").transform.localScale = new Vector3(myRad, myRad, myRad);
            if (GUILayout.Button("Ajouter un onglet à l'intéraction " + (indexInteraction+ 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                myTarget.InstancieNouvelOnglet(i.id);
            }
            foreach(Fenetre f in i.onglets.ToList())
            {
                DrawUILineFat(Color.black,1);
                int indexOnglet = myTarget.interactions.Single(inter => inter.id == i.id).onglets.IndexOf(f);
                EditorGUILayout.LabelField("Onglet n°" + (indexOnglet + 1), "");
                if (GUILayout.Button("Edition mise en page de l'onglet " + (indexOnglet + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    Selection.activeGameObject = GameObject.Find(i.id + "ContentInteraction(Clone)").transform.Find(f.id + "TabContent(Clone)").gameObject;
                }

                if (GUILayout.Button("Supprimer onglet " + (indexOnglet + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    myTarget.RetireOnglet(i.id, f.id);
                }
                
            }

            if (GUILayout.Button("Supprimer Intéraction " + (indexInteraction + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                myTarget.RetireInteraction(i.id);
            }
            
        }

        if (GUI.changed)
        {

            Undo.RecordObject(myTarget, "Saving text");
        }

    }

    void DrawUILineFat(Color color, int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, color);
    }



    static void Callback(object o)
    {
        myTarget.InstancieNouvelleInteraction((Vector3)o);
    }

    public void SetActiveContent(int indexInteraction, int index)
    {
        
    }
}
