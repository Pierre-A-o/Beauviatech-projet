using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class InterviewModelGO : MonoBehaviour
{
    [HideInInspector]
    public List<Interview> interviews;

    private int i;
    private int max;

    [HideInInspector]
    public GameObject prefabInterview;
    [HideInInspector]
    public GameObject content;
    [HideInInspector]
    public GameObject popVideo;
    private GameObject instanceInterview;

    public List<Interview> Interviews { get => interviews; set => interviews = value; }
    public GameObject PrefabInterview { get => prefabInterview; set => prefabInterview = value; }

    public void InstancieNouveauInterview()
    {
        if(interviews == null)
        {
            i = 0;
            interviews = new List<Interview>();
        }
        else if (interviews.Count == 0)
        {
            i = 0;
            max = 0;
        }
        else
        {
            foreach (Interview interview in interviews)
            {
                if (interview.id > max)
                {
                    max = interview.id;
                }
            }
            i = max + 1;
        }
        instanceInterview = Instantiate(prefabInterview, content.transform);
        instanceInterview.name = i + instanceInterview.name;

        UnityAction<int> methodDelegate1 = Delegate.CreateDelegate(typeof(UnityAction<int>), this, "AfficherInterview") as UnityAction<int>;
#if UNITY_EDITOR
        UnityEditor.Events.UnityEventTools.AddIntPersistentListener(instanceInterview.GetComponentInChildren<Button>().onClick, methodDelegate1, i);
 #endif
        interviews.Add(new Interview(i, instanceInterview.transform.Find("TitreText").GetComponent<TextMeshProUGUI>(), instanceInterview.GetComponentInChildren<Button>(), instanceInterview.GetComponent<Image>(), ""));
    }

    public void AfficherInterview(int id)
    {
        Interview interview = interviews.Single(it => it.id == id);
        popVideo.SetActive(true);
        popVideo.GetComponentInChildren<VideoPlayer>().url = System.IO.Path.Combine(Application.streamingAssetsPath, interview.filename);
        popVideo.GetComponentInChildren<VideoPlayer>().Play();
    }

    public void RetireInterview(int id)
    {
        Interview i = interviews.Single(it => it.id == id);
        GameObject toDestroyInterview = content.transform.Find(i.id + "PatternVideo(Clone)").gameObject;
        DestroyImmediate(toDestroyInterview);
        interviews.Remove(i);
    }
}

[System.Serializable]
public class Interview
{
    public TextMeshProUGUI titre;
    public Button lectureButton;
    public Image miniature;
    public string filename;
    [HideInInspector]
    public int id;

    public Interview(int id, TextMeshProUGUI titre, Button lectureButton, Image miniature, string filename)
    {
        this.id = id;
        this.titre = titre;
        this.lectureButton = lectureButton;
        this.miniature = miniature;
        this.filename = filename;
    }

    public TextMeshProUGUI Titre { get => titre; set => titre = value; }
    public Button LectureButton { get => lectureButton; set => lectureButton = value; }
    public Image Miniature { get => miniature; set => miniature = value; }
    public int Id { get => id; set => id = value; }
    public string Filename { get => filename; set => filename = value; }
}
