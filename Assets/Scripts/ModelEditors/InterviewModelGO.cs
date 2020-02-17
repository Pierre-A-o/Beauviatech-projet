using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterviewModelGO : MonoBehaviour
{
    public List<Interview> interviews;

    private int i;
    private int max;

    public GameObject prefabInterview;
    public GameObject content;
    private GameObject instanceInterview;

    public List<Interview> Interviews { get => interviews; set => interviews = value; }
    public GameObject PrefabInterview { get => prefabInterview; set => prefabInterview = value; }

    public void InstancieNouveauInterview()
    {
        if (interviews.Count == 0)
        {
            i = 0;
        }
        else
        {
            foreach (Interview interview in interviews)
            {
                if (interview.id > max)
                {
                    max = interview.id;
                    UnityEditor.Events.UnityEventTools.AddPersistentListener(interview.lectureButton.onClick, () => AfficherInterview(i));
                }
            }
            i = max + 1;
        }
        instanceInterview = Instantiate(prefabInterview, content.transform);
        // autre prefab

        instanceInterview.name = i + instanceInterview.name;


        //interviews.Add(new Interview(i, instanceInterview.transform.Find("TitreText").GetComponent<TextMeshProUGUI>(), instanceInterview.GetComponent<Button>(), instanceFilm.GetComponentInChildren<RawImage>(), instanceFilm.transform.Find("DetailsTexte").GetComponent<TextMeshProUGUI>()));
    }

    public void AfficherInterview(int index)
    {
        /*Film film = elements.ElementAt(index);
        Debug.Log(film.Id);
        foreach (Film f in elements)
        {
            if (f.Equals(film))
            {
                panelExtraitFilm.transform.Find(f.id + "AfficheFilm(Clone)").GetComponent<CanvasGroup>().alpha = 1;
            }
            else
            {
                panelExtraitFilm.transform.Find(f.id + "AfficheFilm(Clone)").GetComponent<CanvasGroup>().alpha = 0;
            }
        }

        panelDescription.GetComponent<CanvasGroup>().alpha = 0;
        panelExtraitFilm.GetComponent<CanvasGroup>().alpha = 1;*/
    }
}

public class Interview
{
    public TextMeshProUGUI titre;
    public Button lectureButton;
    public RawImage video;
    public Image miniature;
    [HideInInspector]
    public int id;

    public Interview(int id, TextMeshProUGUI titre, Button lectureButton, RawImage video, Image miniature)
    {
        this.id = id;
        this.titre = titre;
        this.lectureButton = lectureButton;
        this.video = video;
        this.miniature = miniature;
    }

    public TextMeshProUGUI Titre { get => titre; set => titre = value; }
    public Button LectureButton { get => lectureButton; set => lectureButton = value; }
    public RawImage Video { get => video; set => video = value; }
    public Image Miniature { get => miniature; set => miniature = value; }
    public int Id { get => id; set => id = value; }
}
