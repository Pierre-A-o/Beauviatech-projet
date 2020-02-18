using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FilmoController : MonoBehaviour
{
    public Color myblue;
    public GameObject description_panel;
    public GameObject extrait_panel;
    public GameObject pres_panel;
    public GameObject listeDeFilms;
    public TextMeshProUGUI presentation;
    public TextMeshProUGUI filmographie;

    // Start is called before the first frame update
    void Start()
    {
        pres_panel.SetActive(false);
        description_panel.SetActive(false);
        extrait_panel.SetActive(false);
        listeDeFilms.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToPrésentation()
    {
        GetComponent<PanelManager>().DisparitionP();

        pres_panel.SetActive(true);
        description_panel.SetActive(false);
        extrait_panel.SetActive(false);
        listeDeFilms.SetActive(false);

        presentation.color = myblue;
        filmographie.color = Color.white;

    }

    public void GoToFilmographie()
    {
        pres_panel.SetActive(false);
        description_panel.SetActive(true);
        extrait_panel.SetActive(false);
        listeDeFilms.SetActive(true);

        filmographie.color = myblue;
        presentation.color = Color.white;
    }    

    public void GoToPrincipal()
    {
        pres_panel.SetActive(false);
        description_panel.SetActive(false);
        extrait_panel.SetActive(false);
        listeDeFilms.SetActive(false);

        filmographie.color = Color.white;
        presentation.color = Color.white;
    }
}
