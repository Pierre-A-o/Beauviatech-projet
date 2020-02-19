using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

[CustomEditor(typeof(InterviewModelGO))]
public class InterviewScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InterviewModelGO myTarget = (InterviewModelGO)target;

        if (GUILayout.Button("Ajouter une interview", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            myTarget.InstancieNouveauInterview();  
        }

        foreach(Interview i in myTarget.interviews.ToList())
        {

            int index = myTarget.interviews.IndexOf(i);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Interview n°" + (index+1), "");
            EditorGUILayout.LabelField("Titre de l'interview", "");
            myTarget.interviews[index].titre.text = EditorGUILayout.TextArea(myTarget.interviews[index].titre.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

            if (GUILayout.Button("Charger miniature n°" + (index + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                string file = EditorUtility.OpenFilePanel("Miniature interview n°" + (index + 1), Application.dataPath + "/Resources/Sprites", "jpg,png,bmp,jpeg");

                if (file != null)
                {
                    int length = file.Split('/').Length;
                    string fileName = file.Split('/')[length - 1];

                    string[] stringTab = fileName.Split('.');
                    string final = "";
                    for (int j = 0; j < stringTab.Length - 1; j++)
                    {
                        final += stringTab[j];
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
                    myTarget.interviews[index].miniature.sprite = texture;
                }
            }


            if (GUILayout.Button("Charger l'interview n°" + (index + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                string file = EditorUtility.OpenFilePanel("Interview n°" + (index + 1), Application.dataPath + "/Resources/Videos", "mp4");

                if (file != null)
                {
                    int length = file.Split('/').Length;
                    string fileName = file.Split('/')[length - 1];

                    string[] stringTab = fileName.Split('.');
                    string final = "";
                    for (int j = 0; j < stringTab.Length - 1; j++)
                    {
                        final += stringTab[j];
                    }

                    final.Replace('.', '_');
                    string finalFinal = final + '.' + stringTab[stringTab.Length - 1];


                    if (!File.Exists("Assets/Resources/Videos/" + finalFinal))
                    {
                        File.Copy(file, "Assets/Resources/Videos/" + finalFinal);
                    }
                    
                    AssetDatabase.Refresh();
                    AssetDatabase.ImportAsset("Assets/Resources/Videos/" + finalFinal, ImportAssetOptions.ImportRecursive);
                    
                    VideoClip video = Resources.Load<VideoClip>("Videos/" + final);
                
                    myTarget.interviews[index].video = video;
                }

            }
            if (GUILayout.Button("Supprimer interview n°" + (index + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                myTarget.RetireInterview(i.id);
            }
        }

        if (GUI.changed)
        {
            foreach (Interview i in myTarget.interviews.ToList())
            {
                int index = myTarget.interviews.IndexOf(i);
                EditorUtility.SetDirty(myTarget.interviews[index].titre);
            }

            Undo.RecordObject(myTarget, "Saving text");
        }
    }
}