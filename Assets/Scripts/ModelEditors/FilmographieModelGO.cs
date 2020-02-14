using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Video;

public class FilmographieModelGO : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI description;
   
    public List<Film> elements;

    private int i;
    private int max;

    // Outils pour génération liste films
    private GameObject instanceFilm;
    private GameObject instanceBouton;

    public GameObject listeExtraitFilms;
    public GameObject prefabFilm;
    public GameObject prefabBoutonFilm;
    public GameObject listeDeFilms;
    public GameObject panelExtraitFilm;


    public TextMeshProUGUI Description { get => description; set => description = value; }
  
    public List<Film> Elements { get => elements; set => elements = value; }
    public GameObject ListeExtraitFilms { get => listeExtraitFilms; set => listeExtraitFilms = value; }
    public GameObject PrefabFilm { get => prefabFilm; set => prefabFilm = value; }
    public GameObject PrefabBoutonFilm { get => prefabBoutonFilm; set => prefabBoutonFilm = value; }
    public GameObject ListeDeFilms { get => listeDeFilms; set => listeDeFilms = value; }
    public GameObject PanelExtraitFilm { get => panelExtraitFilm; set => panelExtraitFilm = value; }

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

        elements.Add(new Film(i, instanceFilm.transform.Find("FilmTitre").GetComponent<TextMeshProUGUI>(),instanceBouton.GetComponent<Image>(), instanceFilm.GetComponentInChildren<RawImage>(),instanceFilm.transform.Find("DetailsTexte").GetComponent<TextMeshProUGUI>()));
    }

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

}

[System.Serializable]
public class Film
{
    public TextMeshProUGUI titre;
    public Image image;
    public RawImage video;
    public TextMeshProUGUI description;
    public int id;

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