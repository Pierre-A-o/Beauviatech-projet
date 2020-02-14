using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomEditor(typeof(FilmographieModelGO))]
public class FilmographieEditor : Editor
{
    FilmographieModelGO myTarget;


    void OnEnable()
    {
        myTarget = (FilmographieModelGO)target;

    }

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
       

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Ajouter un film"))
        {
            myTarget.InstancieNouveauFilm();   
        }

        for (int i = 0; i < myTarget.elements.Count; i++)
        {
            EditorGUILayout.LabelField("Film n°" + (i + 1), "");
            EditorGUILayout.LabelField("Titre du film", "");
            myTarget.elements[i].titre.text = EditorGUILayout.TextArea(myTarget.elements[i].titre.text);

            if (GUILayout.Button("Retirer Film"))
            {
                myTarget.RemoveIndex(i);
            }
        }

        

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Description", "");
        myTarget.description.text = EditorGUILayout.TextArea(myTarget.description.text);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget.description);
            Undo.RecordObject(myTarget, "Saving text");
        }


    }
}
