using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class ModelModelGO : MonoBehaviour
{
    public List<Interaction> interactions;
    public GameObject cameraModel;
    
    public GameObject prefabInteraction;
    
    public GameObject prefabOngletButton;
    
    public GameObject prefabOngletContent;
    
    public GameObject ongletPanel;
    
    public GameObject scrollView;

    private int i;
    private int maxI;
    private int j;
    private int maxJ;

    private GameObject instanceInteraction;
    private GameObject instanceOngletButton;
    private GameObject instanceOngletContent;

    public void InstancieNouvelleInteraction(Vector3 position)
    {
        if (interactions == null)
        {
            interactions = new List<Interaction>();
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
        instanceInteraction = Instantiate(prefabInteraction, cameraModel.transform);
        instanceInteraction.name = i + instanceInteraction.name;
        instanceInteraction.transform.position = position;

        //voir si on met une valeur de base à un radius
        float rad = 10f;
        interactions.Add(new Interaction(i, rad, instanceInteraction.transform.position, new List<Fenetre>()));
        Debug.Log(interactions.Count);
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

        instanceOngletButton = Instantiate(prefabOngletButton, ongletPanel.transform);
        instanceOngletButton.name = j + instanceOngletButton.name;
        instanceOngletContent = Instantiate(prefabOngletContent, scrollView.transform);
        instanceOngletContent.name = j + instanceOngletContent.name;
        interaction.onglets.Add(new Fenetre(j, instanceOngletButton.GetComponent<TextMeshProUGUI>(), new List<GameObject>()));
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
