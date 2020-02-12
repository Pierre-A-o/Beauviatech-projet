using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PresentationModelGO))]
public class PresentationScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PresentationModelGO myTarget = (PresentationModelGO)target;

        EditorGUILayout.LabelField("Texte supérieur gauche", "");
        myTarget.text1.text = EditorGUILayout.TextArea(myTarget.text1.text);
        EditorGUILayout.LabelField("Texte inférieur droite", "");
        myTarget.text2.text = EditorGUILayout.TextArea(myTarget.text2.text);
        EditorGUILayout.LabelField("Image supérieure droite", "");
        // image 1
        if (GUILayout.Button("Charger image 1"))
        {
            string file = EditorUtility.OpenFilePanel("Image 1", "", "jpg,png,bmp,jpeg");
            if (file != null)
            {
                var fileContent = File.ReadAllBytes(file);
                myTarget.image1.sprite.texture.LoadImage(fileContent);
            }
        }

        EditorGUILayout.LabelField("Image inférieure gauche", "");
        // image 2
        if (GUILayout.Button("Charger image 2"))
        {
           
            string file = EditorUtility.OpenFilePanel("Image 2", "", "jpg,png,bmp,jpeg");
            
            if (file != null)
            {
                int length = file.Split('/').Length;
                string fileName = file.Split('/')[length - 1];
           
                //File.Copy(file, "Assets/Resources/Sprites/" + fileName);

                //AssetDatabase.Refresh();

                TextureImporter tImporter = AssetImporter.GetAtPath("Assets/Resources/Sprites/" + fileName) as TextureImporter;
                tImporter.textureType = TextureImporterType.Sprite;
                //tImporter.textureFormat = TextureImporterFormat.DXT5;

                AssetDatabase.Refresh();

                Sprite texture = Resources.Load("Assets/Resources/Sprites/" + fileName) as Sprite;
                myTarget.image2.sprite = texture;
            }
        }


        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget.text1);
            EditorUtility.SetDirty(myTarget.text2);

            Undo.RecordObject(myTarget, "Saving text");
        }

    }
}
