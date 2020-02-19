using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class ModelModelGO : MonoBehaviour
{
    public List<Interaction> interactions;
 
    public GameObject cameraModel;
    [HideInInspector]
    public GameObject prefabInteraction;
    [HideInInspector]
    public GameObject prefabOngletButton;
    [HideInInspector]
    public GameObject prefabOngletContent;
    [HideInInspector]
    public GameObject prefabContentInteraction;
    [HideInInspector]
    public GameObject prefabTabContainer;
    [HideInInspector]
    public GameObject ongletPanel;
    [HideInInspector]
    public GameObject viewPort;


    private int i;
    private int maxI;
    private int j;
    private int maxJ;
    private float rad = 0.1f;

    private GameObject instanceInteraction;
    private GameObject instanceOngletButton;
    private GameObject instanceOngletContent;
    private GameObject instanceContentInteraction;
    private GameObject instanceButtonInteraction;
  

    public void InstancieNouvelleInteraction(Vector3 position)
    {
        if (interactions == null)
        {
            interactions = new List<Interaction>();
            i = 0;
        }
        else if (interactions.Count == 0)
        {
            i = 0;
        }
        else
        {
            foreach (Interaction interaction in interactions)
            {
                if (interaction.id > maxI)
                {
                    maxI = interaction.id;
                }
            }
            i = maxI + 1;
        }
      
        //Création de la zone clique
        instanceInteraction = Instantiate(prefabInteraction, cameraModel.transform);
        instanceInteraction.name = i + instanceInteraction.name;
        instanceInteraction.transform.localScale = new Vector3(rad, rad, rad);
        instanceInteraction.transform.position = position;

        //Création du content lié à la zone clique
        instanceContentInteraction = Instantiate(prefabContentInteraction, viewPort.transform);
        instanceContentInteraction.name = i + instanceContentInteraction.name;

        //Création du conteneur des onglets
        instanceButtonInteraction = Instantiate(prefabTabContainer, ongletPanel.transform);
        instanceButtonInteraction.name = i + instanceButtonInteraction.name;

        interactions.Add(new Interaction(i, instanceInteraction.transform.localScale.x, instanceInteraction.transform.position, new List<Fenetre>()));
    }

    public void InstancieNouvelOnglet(int index)
    {
        Interaction interaction = interactions.ElementAt(index);
        if (interaction.onglets.Count == 0)
        {
            j = 0;
        }
        else
        {
            foreach (Fenetre onglet in interaction.onglets)
            {
                if (onglet.id > maxJ)
                {
                    maxJ = onglet.id;
                }
            }
            j = maxJ + 1;
        }

        GameObject myContent = viewPort.transform.Find(index + "ContentInteraction(Clone)").gameObject;
        GameObject myContainer = ongletPanel.transform.Find(index + "TabContainer(Clone)").gameObject;

        instanceOngletButton = Instantiate(prefabOngletButton, myContainer.transform);
        instanceOngletButton.name = j + instanceOngletButton.name;
        instanceOngletContent = Instantiate(prefabOngletContent, myContent.transform);
        instanceOngletContent.name = j + instanceOngletContent.name;

  
        instanceOngletContent.AddComponent<TablModelGO>();
        instanceOngletContent.GetComponent<TablModelGO>().nom = instanceOngletButton.GetComponentInChildren<TextMeshProUGUI>();
        instanceOngletContent.GetComponent<TablModelGO>().contenu = new List<Contenu>();
        instanceOngletContent.GetComponent<TablModelGO>().IndexInteraction = i;
        instanceOngletContent.GetComponent<TablModelGO>().IndexOnglet = j;
        interaction.onglets.Add(new Fenetre(j, instanceOngletButton.GetComponentInChildren<TextMeshProUGUI>(), new List<GameObject>()));


    }

    public void AjouteContenu(int i, int j, GameObject contenu)
    {
        Interaction interaction = interactions.Single(it => it.id == i);
        Fenetre onglet = interaction.onglets.Single(on => on.id == j);
        onglet.contenu.Add(contenu);
    }

    public void InstancieNouveauContenu(int interactionIndex, int ongletIndex)
    {
        Interaction interaction = interactions.ElementAt(interactionIndex);
        Fenetre onglet = interaction.onglets.ElementAt(ongletIndex);
    }
}

[System.Serializable]
public class Interaction
{
    public int id;
    
    public float radius;
    
    public Vector3 position;
    public List<Fenetre> onglets;

    public Interaction(int id, float radius, Vector3 position, List<Fenetre> onglets)
    {
        Id = id;
        Radius = radius;
        Position = position;
        Onglets = onglets;
    }

    public void ajoutOnglet(Fenetre onglet)
    {
        onglets.Add(onglet);
    }

    public void retireOnglet(int index)
    {
        onglets.RemoveAt(index);
    }

    public int Id { get => id; set => id = value; }
    public float Radius { get => radius; set => radius = value; }
    public Vector3 Position { get => position; set => position = value; }
    public List<Fenetre> Onglets { get => onglets; set => onglets = value; }
}

[System.Serializable]
public class Fenetre
{
    public int id;
    public TextMeshProUGUI nom;
    public List<GameObject> contenu;

    public Fenetre()
    {

    }
    public Fenetre(int id, TextMeshProUGUI nom, List<GameObject> contenu)
    {
        this.id = id;
        this.nom = nom;
        this.contenu = contenu;
    }

    public int Id { get => id; set => id = value; }
    public TextMeshProUGUI Nom { get => nom; set => nom = value; }
    public List<GameObject> Contenu { get => contenu; set => contenu = value; }
}
