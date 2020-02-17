using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
        pres_panel.GetComponent<CanvasGroup>().alpha = 1;
        description_panel.GetComponent<CanvasGroup>().alpha = 0;
        extrait_panel.GetComponent<CanvasGroup>().alpha = 0;
        listeDeFilms.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        listeDeFilms.GetComponent<CanvasGroup>().alpha = 1;
        extrait_panel.GetComponent<CanvasGroup>().alpha = 0;
        pres_panel.SetActive(false);
        filmographie.color = myblue;
        presentation.color = Color.white;
    }    

    public void GoToPrincipal()
    {
        SceneManager.LoadScene("FirstCameraScene");
    }
}
