﻿using System.Collections;
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

        EditorGUILayout.HelpBox("Glissez les images de Assets/Sprites ici.", MessageType.Info);

        EditorGUILayout.LabelField("Texte supérieur gauche", "");
        myTarget.text1.text = EditorGUILayout.TextArea(myTarget.text1.text);
        EditorGUILayout.LabelField("Texte inférieur droite", "");
        myTarget.text2.text = EditorGUILayout.TextArea(myTarget.text2.text);

        EditorGUILayout.HelpBox("Rentrez les textes que vous désirez ci-dessus.", MessageType.Info);

        EditorGUILayout.LabelField("Image supérieure droite", "");

        // image 1
        if (GUILayout.Button("Charger image 1"))
        {
            string file = EditorUtility.OpenFilePanel("Image 1", Application.dataPath + "/Resources/Sprites", "jpg,png,bmp,jpeg");

            if (file != null)
            {
                int length = file.Split('/').Length;
                string fileName = file.Split('/')[length - 1];

                string[] stringTab = fileName.Split('.');
                string final = "";
                for (int i = 0; i < stringTab.Length - 1; i++)
                {
                    final += stringTab[i];
                }

                final.Replace('.', '_');
                string finalFinal = final + '.' + stringTab[stringTab.Length - 1];


                if (!File.Exists("Assets/Resources/Sprites/" + finalFinal))
                {
                    File.Copy(file, "Assets/Resources/Sprites/" + finalFinal);
                }


                AssetDatabase.Refresh();
                TextureImporter tImporter = AssetImporter.GetAtPath("Assets/Resources/Sprites/" + finalFinal) as TextureImporter;
                tImporter.textureType = TextureImporterType.Sprite;

                AssetDatabase.ImportAsset("Assets/Resources/Sprites/" + finalFinal, ImportAssetOptions.ImportRecursive);


                Sprite texture = Resources.Load<Sprite>("Sprites/" + final);
                myTarget.spriteImage1 = null;
                myTarget.image1.sprite = texture;
            }
        }

        EditorGUILayout.LabelField("Image inférieure gauche", "");
        // image 2
        if (GUILayout.Button("Charger image 2"))
        {

            string file = EditorUtility.OpenFilePanel("Image 2", Application.dataPath+ "/Resources/Sprites", "jpg,png,bmp,jpeg");
            
            if (file != null)
            {
                int length = file.Split('/').Length;
                string fileName = file.Split('/')[length - 1];

                string[] stringTab = fileName.Split('.');
                string final = "";
                for (int i = 0; i < stringTab.Length - 1; i++)
                {
                    final += stringTab[i];
                }

                final.Replace('.', '_');
                string finalFinal = final + '.' + stringTab[stringTab.Length-1];


                if (!File.Exists("Assets/Resources/Sprites/" + finalFinal))
                {
                    File.Copy(file, "Assets/Resources/Sprites/" + finalFinal);
                }
               

                AssetDatabase.Refresh();
                TextureImporter tImporter = AssetImporter.GetAtPath("Assets/Resources/Sprites/" + finalFinal) as TextureImporter;
                tImporter.textureType = TextureImporterType.Sprite;

                AssetDatabase.ImportAsset("Assets/Resources/Sprites/" + finalFinal, ImportAssetOptions.ImportRecursive);
             

                Sprite texture = Resources.Load<Sprite>("Sprites/" + final);
                myTarget.spriteImage2 = null;
                myTarget.image2.sprite = texture;
            }

        }


        EditorGUILayout.HelpBox("Chargez vos images à partir de vos dossiers en utilisant les deux boutons ci-dessus.", MessageType.Info);


        if (myTarget.spriteImage1 != null)
        {
            myTarget.image1.sprite = myTarget.spriteImage1;
        } 
        if (myTarget.spriteImage2 != null)
        {
            myTarget.image2.sprite = myTarget.spriteImage2;
        }


        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget.text1);
            EditorUtility.SetDirty(myTarget.text2);

            Undo.RecordObject(myTarget, "Saving text");
        }

    }
}
