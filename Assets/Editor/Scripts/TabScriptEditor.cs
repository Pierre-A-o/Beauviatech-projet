using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[CustomEditor(typeof(TablModelGO))]
public class TabScriptEditor : Editor
{
    private TablModelGO myTarget;
    private GameObject theModel;

    private int i;
    private int max;

    private void OnEnable()
    {
        myTarget = (TablModelGO)target;
        theModel = GameObject.Find("ModelEditor").gameObject;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(myTarget.contenu == null)
        {
            i = 0;
            myTarget.contenu = new List<Contenu>();
        }
        else if (myTarget.contenu.Count == 0)
        {
            i = 0;
        }
        else
        {
            foreach (Contenu c in myTarget.contenu)
            {
                if (c.Id > max)
                {
                    max = c.Id;
                }
            }
            i = max + 1;
        }

        EditorGUILayout.LabelField("Nom de l'onglet", "");
        myTarget.nom.text = EditorGUILayout.TextField(myTarget.nom.text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });
        DrawUILine(Color.black);
        if (GUILayout.Button("Ajouter Titre", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            GameObject myTitle = new GameObject("Titre" + (i + 1));
            myTitle.transform.parent = myTarget.gameObject.transform;
            myTitle.AddComponent<TextMeshProUGUI>();
            Contenu contenu = new Contenu(i, myTitle);
            myTarget.contenu.Add(contenu);
            theModel.GetComponent<ModelModelGO>().AjouteContenu(myTarget.IndexInteraction,myTarget.IndexOnglet,myTitle);
        }

        if (GUILayout.Button("Ajouter Paragraphe", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            GameObject myParagraphe = new GameObject("Paragraphe" + (i + 1));
            myParagraphe.transform.parent = myTarget.gameObject.transform;
            myParagraphe.AddComponent<TextMeshProUGUI>();
            Contenu contenu = new Contenu(i, myParagraphe);
            myTarget.contenu.Add(contenu);
            theModel.GetComponent<ModelModelGO>().AjouteContenu(myTarget.IndexInteraction, myTarget.IndexOnglet, myParagraphe);
        }

        if (GUILayout.Button("Ajouter Image", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            GameObject myImage = new GameObject("Image" + (i + 1));
            myImage.transform.parent = myTarget.gameObject.transform;
            myImage.AddComponent<Image>();
            Contenu contenu = new Contenu(i, myImage);
            myTarget.contenu.Add(contenu);
            theModel.GetComponent<ModelModelGO>().AjouteContenu(myTarget.IndexInteraction, myTarget.IndexOnglet, myImage);
        }

        if (GUILayout.Button("Ajouter Vidéo", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            GameObject myVideo = new GameObject("Video" + (i + 1));
            myVideo.transform.parent = myTarget.gameObject.transform;
            myVideo.AddComponent<RawImage>();
            myVideo.AddComponent<VideoPlayer>();
            myVideo.GetComponent<VideoPlayer>().playOnAwake = false;

            string filename = "renderTexture" + (myTarget.contenu.Count + 1);

            RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
            rt.Create();

            //RenderTexture rt = Resources.Load<RenderTexture>("Videos/New Render Texture");
            var renderTexture = AssetDatabase.LoadAssetAtPath<RenderTexture>("Assets/Resources/Videos/CopyRender.renderTexture");
            var cloneAsset = UnityEngine.Object.Instantiate(renderTexture);
            try
            {
                AssetDatabase.CreateAsset(cloneAsset, "Assets/Resources/Videos/" + filename+".renderTexture");
            }
            catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Error cloning asset", "OK");
                return;
            }
            myVideo.GetComponent<VideoPlayer>().targetTexture = Resources.Load<RenderTexture>("Videos/" + filename);
            myVideo.GetComponent<RawImage>().texture = Resources.Load<Texture>("Videos/" + filename);
            Contenu contenu = new Contenu(i, myVideo);
            myTarget.contenu.Add(contenu);
            theModel.GetComponent<ModelModelGO>().AjouteContenu(myTarget.IndexInteraction, myTarget.IndexOnglet, myVideo);
        }

        DrawUILine(Color.black);

        foreach (Contenu go in myTarget.contenu.ToList())
        {
            if (go.Objet.GetComponent<TextMeshProUGUI>() != null)
            {
                if (go.Objet.name.StartsWith("P"))
                {
                    EditorGUILayout.LabelField("Paragraphe " + (myTarget.contenu.IndexOf(go) + 1), "");

                    go.Objet.GetComponent<TextMeshProUGUI>().text = EditorGUILayout.TextArea(go.Objet.GetComponent<TextMeshProUGUI>().text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

                    if (GUILayout.Button("Supprimer le paragraphe " + (myTarget.contenu.IndexOf(go) + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                    {
                        myTarget.RetireComposant(go.Id, "Paragraphe");
                    }
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }

                else
                {
                    EditorGUILayout.LabelField("Titre " + (myTarget.contenu.IndexOf(go) + 1), "");

                    go.Objet.GetComponent<TextMeshProUGUI>().text = EditorGUILayout.TextField(go.Objet.GetComponent<TextMeshProUGUI>().text, new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) });

                    if (GUILayout.Button("Supprimer le titre " + (myTarget.contenu.IndexOf(go) + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                    {
                        myTarget.RetireComposant(go.Id, "Titre");
                    }
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                    EditorGUILayout.Space();
                }
            }


            else if (go.Objet.GetComponent<Image>() != null)
            {
                EditorGUILayout.LabelField("Image " + (myTarget.contenu.IndexOf(go) + 1), "");
                if (GUILayout.Button("Charger image" + (myTarget.contenu.IndexOf(go) + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    string file = EditorUtility.OpenFilePanel("Image film n°" + (myTarget.contenu.IndexOf(go) + 1), Application.dataPath + "/Resources/Sprites", "jpg,png,bmp,jpeg");

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
                        go.Objet.GetComponent<Image>().sprite = texture;

                    }

                    
                }
                if (GUILayout.Button("Supprimer l'image " + (myTarget.contenu.IndexOf(go) + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    myTarget.RetireComposant(go.Id, "Image");
                }
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }

            else if (go.Objet.GetComponent<VideoPlayer>() != null)
            {
                if (GUILayout.Button("Charger film " + (myTarget.contenu.IndexOf(go) + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    string file = EditorUtility.OpenFilePanel("Film " + (myTarget.contenu.IndexOf(go) + 1), Application.dataPath + "/Resources/Videos", "mp4");

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
                        go.Objet.GetComponent<VideoPlayer>().clip = video;
                    }
                }
                if (GUILayout.Button("Supprimer la vidéo " + (myTarget.contenu.IndexOf(go) + 1), new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
                {
                    myTarget.RetireComposant(go.Id, "Video");
                }
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }
            
        }
        DrawUILine(Color.black);
        if (GUILayout.Button("Retour Editeur", new GUILayoutOption[] { GUILayout.MaxWidth(400.0f) }))
        {
            Selection.activeObject = theModel;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(myTarget.nom);
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
