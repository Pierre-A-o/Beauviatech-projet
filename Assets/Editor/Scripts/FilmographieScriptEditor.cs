using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

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
        EditorGUILayout.HelpBox("Appuyez sur le bouton suivant pour ajouter un film.", MessageType.Info);
        if (GUILayout.Button("Ajouter un film", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            myTarget.InstancieNouveauFilm();
        }

        DrawUILine(Color.black);

        for (int i = 0; i < myTarget.elements.Count; i++)
        {
            EditorGUILayout.LabelField("Film n°" + (i + 1), "");
            EditorGUILayout.LabelField("Titre du film", "");
            myTarget.elements[i].titre.text = EditorGUILayout.TextArea(myTarget.elements[i].titre.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
            EditorGUILayout.LabelField("Image du film", "");
            // image
            if (GUILayout.Button("Charger image du film n°" + (i + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                string file = EditorUtility.OpenFilePanel("Image film n°" + (i + 1), Application.dataPath + "/Resources/Sprites", "jpg,png,bmp,jpeg");

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
                    myTarget.elements[i].spriteImage = null;
                    myTarget.elements[i].image.sprite = texture;
                }
            }

            if (myTarget.elements[i].spriteImage != null)
            {
                myTarget.elements[i].image.sprite = myTarget.elements[i].spriteImage;
            }

            // video à faire
            if (GUILayout.Button("Charger l'extrait du film n°" + (i + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                string file = EditorUtility.OpenFilePanel("Extrait film n°" + (i + 1), Application.dataPath + "/Resources/Videos", "mp4");

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
                    TextureImporter tImporter = AssetImporter.GetAtPath("Assets/Resources/Videos/" + finalFinal) as TextureImporter;
                    //à changer
                    tImporter.textureType = TextureImporterType.Sprite;

                    AssetDatabase.ImportAsset("Assets/Resources/Videos/" + finalFinal, ImportAssetOptions.ImportRecursive);


                    VideoPlayer video = Resources.Load<VideoPlayer>("Videos/" + final);
                    //à continuer
                    myTarget.elements[i].video.texture = video.targetTexture;
                }

                if (myTarget.elements[i].spriteImage != null)
                {
                    myTarget.elements[i].image.sprite = myTarget.elements[i].spriteImage;
                }
            }

            EditorGUILayout.LabelField("Détails du film", "");
            myTarget.elements[i].description.text = EditorGUILayout.TextArea(myTarget.elements[i].description.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

            if (GUILayout.Button("Retirer Film n°" + (i + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
            {
                myTarget.RemoveIndex(i);
            }
            DrawUILine(Color.black);
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Modifiez le message affiché sur la description de la page filmographie.", MessageType.Info);
        EditorGUILayout.LabelField("Description", "");
        myTarget.description.text = EditorGUILayout.TextArea(myTarget.description.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget.description);
            Undo.RecordObject(myTarget, "Saving text");
        }

    }

    void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, color);
    }
}