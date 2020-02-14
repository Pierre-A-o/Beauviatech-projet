using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class FilmoController : MonoBehaviour
{
    private List<Extrait_Film> extraits;
    private GameObject instance;
    private Extrait_Film film;

    public Color myblue;

    public GameObject description_panel;
    public GameObject extrait_panel;
    public GameObject pres_panel;
    public TextMeshProUGUI presentation;
    public TextMeshProUGUI filmographie;
    public GameObject prefabFilm;
    public GameObject prefabBoutonFilm;
    public GameObject listeExtraitFilms;
    public GameObject listeDeFilms;


    // Start is called before the first frame update
    void Start()
    {
        extraits = new List<Extrait_Film>();
        extraits.Add(new Extrait_Film
        {
            Description = "ohlalala angelina jolie ohlalala disney ohlalala",
            Nom_film = "Malefique",
            Nom_miniature = "malefique"
        });
        extraits.Add(new Extrait_Film
        {
            Description = "C'est une petite fille qui fait un voyage de ouf ohlalala",
            Nom_film = "Alice au pays des merveilles",
            Nom_miniature = "alice"
        });
        extraits.Add(new Extrait_Film
        {
            Description = "cf Alice mais il y a un dragon stylé et des petits cochons",
            Nom_film = "Le voyage de Chihiro",
            Nom_miniature = "chihiro"
        });
        extraits.Add(new Extrait_Film
        {
            Description = "C'est un chasseur qui dort, il meurt",
            Nom_film = "La nuit du chasseur",
            Nom_miniature = "chasseur"
        });
        extraits.Add(new Extrait_Film
        {
            Description = "Je l'ai toujours pas vu donc je sais pas de quoi ça parle je suis désolé",
            Nom_film = "Akira",
            Nom_miniature = "Akira"
        });
        extraits.Add(new Extrait_Film
        {
            Description = "Hollywood c'est trop SWAG",
            Nom_film = "Mulholland drive",
            Nom_miniature = "mulholland"
        });
        foreach (Extrait_Film extrait in extraits)
        {
            instance = Instantiate(prefabBoutonFilm, listeExtraitFilms.transform);
            var sprite = Resources.Load<Sprite>("Sprites/"+extrait.Nom_miniature);
            instance.GetComponent<Button>().image.sprite = sprite;
            instance.GetComponent<Button>().onClick.AddListener(delegate {AfficherFilm(extrait.Nom_film);});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstancierNouveauFilm()
    {
   
    }

    void AfficherFilm(string s)
    {
        film = extraits.Find(item => item.Nom_film.Equals(s));
        foreach(Extrait_Film ex in extraits)
        {
            Debug.Log(ex.Nom_film);
        }
        description_panel.GetComponent<CanvasGroup>().alpha = 0;
        extrait_panel.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void GoToPrésentation()
    {
        description_panel.GetComponent<CanvasGroup>().alpha = 0;
        extrait_panel.GetComponent<CanvasGroup>().alpha = 0;
        listeDeFilms.GetComponent<CanvasGroup>().alpha = 0;
        pres_panel.SetActive(true);
        presentation.color = myblue;
        filmographie.color = Color.white;
    }

    public void GoToFilmographie()
    {
        description_panel.GetComponent<CanvasGroup>().alpha = 1;
        extrait_panel.GetComponent<CanvasGroup>().alpha = 0;
        pres_panel.SetActive(false);
        listeDeFilms.GetComponent<CanvasGroup>().alpha = 1;
        filmographie.color = myblue;
        presentation.color = Color.white;
    }    

    public void GoToPrincipal()
    {
        SceneManager.LoadScene("FirstCameraScene");
    }
}
