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

        EditorGUILayout.LabelField("Texte supérieur gauche", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
        myTarget.text1.text = EditorGUILayout.TextArea(myTarget.text1.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
        EditorGUILayout.LabelField("Texte inférieur droite", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
        myTarget.text2.text = EditorGUILayout.TextArea(myTarget.text2.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

        EditorGUILayout.HelpBox("Rentrez les textes que vous désirez ci-dessus.", MessageType.Info);

        EditorGUILayout.LabelField("Image supérieure droite", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

        // image 1
        if (GUILayout.Button("Charger image 1", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
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
                myTarget.spriteImage1 = texture;
               
            }
        }

        EditorGUILayout.LabelField("Image inférieure gauche", "");
        // image 2
        if (GUILayout.Button("Charger image 2", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
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
                myTarget.spriteImage2 = texture;
              
            }

        }


        EditorGUILayout.HelpBox("Chargez vos images à partir de vos dossiers en utilisant les deux boutons ci-dessus.", MessageType.Info);


        


        if (GUI.changed)
        {
            
            myTarget.image1.sprite = myTarget.spriteImage1;
           
            myTarget.image2.sprite = myTarget.spriteImage2;
           
            EditorUtility.SetDirty(myTarget);
   
            Undo.RecordObject(myTarget, "Saving text");
        }

        if (Selection.activeGameObject != null)
        {
            myTarget.panelDescription.SetActive(false);
            myTarget.panelExtraitFilm.SetActive(false);
            myTarget.listeDeFilms.SetActive(false);
            myTarget.panelPresentation.SetActive(true);

        }

    }
}
