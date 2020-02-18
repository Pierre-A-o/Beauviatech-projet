using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Video;
using UnityEngine.Events;
using System;

public class FilmographieModelGO : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI description;
    [HideInInspector]
    public List<Film> elements;

    private int i;
    private int max;

    // Outils pour génération liste films
    [HideInInspector]
    private GameObject instanceFilm;
    [HideInInspector]
    private GameObject instanceBouton;
    [HideInInspector]
    public GameObject prefabFilm;
    [HideInInspector]
    public GameObject prefabBoutonFilm;
    [HideInInspector]
    public RenderTexture renderVideo;
    [HideInInspector]
    public GameObject panelPresentation;
    [HideInInspector]
    public GameObject listeExtraitFilms;
    [HideInInspector]
    public GameObject panelDescription;
    [HideInInspector]
    public GameObject listeDeFilms;
    [HideInInspector]
    public GameObject panelExtraitFilm;

    [HideInInspector]
    public VideoPlayer videoPlayer;




    public TextMeshProUGUI Description { get => description; set => description = value; }
  
    public List<Film> Elements { get => elements; set => elements = value; }
    public GameObject ListeExtraitFilms { get => listeExtraitFilms; set => listeExtraitFilms = value; }
    public GameObject PrefabFilm { get => prefabFilm; set => prefabFilm = value; }
    public GameObject PrefabBoutonFilm { get => prefabBoutonFilm; set => prefabBoutonFilm = value; }
    public GameObject ListeDeFilms { get => listeDeFilms; set => listeDeFilms = value; }
    public GameObject PanelExtraitFilm { get => panelExtraitFilm; set => panelExtraitFilm = value; }

    /// <summary>
    /// Instancie un nouveau film lorsque l'utilisateur appuie sur le bouton "Ajouter un film". 
    /// Ceci génère deux Prefabs.
    /// </summary>
    public void InstancieNouveauFilm()
    {
        if (elements.Count == 0)
        {
            i = 0;
        }
        else
        {
            foreach(Film f in elements)
            {
                if (f.id > max)
                {
                    max = f.id;
                }
            }
            i = max + 1;
        }
        instanceFilm = Instantiate(prefabFilm, panelExtraitFilm.transform);
        instanceBouton = Instantiate(prefabBoutonFilm, listeExtraitFilms.transform);


        instanceFilm.name = i + instanceFilm.name;
        instanceBouton.name = i + instanceBouton.name;

        //aled
        UnityAction<int> methodDelegate1 = Delegate.CreateDelegate(typeof(UnityAction<int>), this, "AfficherFilm") as UnityAction<int>;
        UnityAction methodDelegate2 = Delegate.CreateDelegate(typeof(UnityAction), this, "ControleVideo") as UnityAction;

        UnityEditor.Events.UnityEventTools.AddIntPersistentListener(instanceBouton.GetComponentInChildren<Button>().onClick,methodDelegate1,i);

        UnityEditor.Events.UnityEventTools.AddPersistentListener(instanceFilm.GetComponentInChildren<Button>().onClick, methodDelegate2);

        elements.Add(new Film(i, instanceFilm.transform.Find("FilmTitre").GetComponent<TextMeshProUGUI>(),instanceBouton.GetComponent<Image>(), instanceFilm.GetComponentInChildren<RawImage>(), instanceFilm.transform.Find("DetailsTexte").GetComponent<TextMeshProUGUI>()));
    }

    public void ControleVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

 

    /// <summary>
    /// Supprime le film de la liste éléments à l'index donné. 
    /// Supprime aussi les deux Prefabs générés lors de sa création.
    /// 
    /// A REVOIR ATTENTION L'INDEX OHLALA
    /// </summary>
    /// <param name="index">Index du film à supprimer.</param>
    public void RemoveIndex(int index)
    {
        Debug.Log(index + "AfficheFilm(Clone)");
        Film filmToDestroy = elements.ElementAt(index);
        GameObject toDestroyFilm =  panelExtraitFilm.transform.Find(filmToDestroy.id + "AfficheFilm(Clone)").gameObject;
        GameObject toDestroyBouton = listeExtraitFilms.transform.Find(filmToDestroy.id + "BoutonExtraitFilmo(Clone)").gameObject;
        DestroyImmediate(toDestroyFilm);
        DestroyImmediate(toDestroyBouton);
        elements.RemoveAt(index);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void AfficherFilm(int index)
    {
        Debug.Log(index);
        Film film = elements[index];
        Debug.Log(elements.Count);
        Debug.Log(film.Id);
        foreach(Film f in elements)
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
        videoPlayer.clip = film.videoClip;
        videoPlayer.Play();
        videoPlayer.Pause();
        panelDescription.SetActive(false);
        panelExtraitFilm.SetActive(true);
    }


}

[System.Serializable]
public class Film
{
    [HideInInspector]
    public TextMeshProUGUI titre;
    [HideInInspector]
    public Image image;
    public Sprite spriteImage;
    public RawImage video;
    [HideInInspector]
    public TextMeshProUGUI description;
    public int id;

    public VideoClip videoClip;


    public Film(int id, TextMeshProUGUI titre, Image image, RawImage video, TextMeshProUGUI description)
    {
        this.id = id;
        this.titre = titre;
        this.image = image;
        this.video = video;
        this.description = description;
    }

    public TextMeshProUGUI Titre { get => titre; set => titre = value; }
    public Image Image { get => image; set => image = value; }
    public RawImage Video { get => video; set => video = value; }
    public TextMeshProUGUI DescElement { get => description; set => description = value; }
    public int Id { get => id; set => id = value; }
}