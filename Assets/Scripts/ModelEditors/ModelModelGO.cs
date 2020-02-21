using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.Video;

public class ModelModelGO : MonoBehaviour
{
    [HideInInspector]
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
            maxI = 0;
            maxJ = 0;
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
        instanceContentInteraction.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
        instanceContentInteraction.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
        instanceContentInteraction.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        instanceContentInteraction.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
        instanceContentInteraction.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);

        //Création du conteneur des onglets
        instanceButtonInteraction = Instantiate(prefabTabContainer, ongletPanel.transform);
        instanceButtonInteraction.name = i + instanceButtonInteraction.name;
        instanceButtonInteraction.AddComponent<GridLayoutGroup>();
        instanceButtonInteraction.GetComponent<GridLayoutGroup>().cellSize = new Vector2 (100f,50f);
        instanceButtonInteraction.AddComponent<ResizeOnglets>();
        instanceButtonInteraction.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 0f);
        instanceButtonInteraction.GetComponent<RectTransform>().anchorMax = new Vector2(1f, 1f);
        instanceButtonInteraction.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        instanceButtonInteraction.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
        instanceButtonInteraction.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
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
        UnityAction<int> methodDelegate = Delegate.CreateDelegate(typeof(UnityAction<int>), this, "AfficherOnglet") as UnityAction<int>;
        UnityEditor.Events.UnityEventTools.AddIntPersistentListener(instanceOngletButton.GetComponentInChildren<Button>().onClick, methodDelegate, j);
        
        instanceOngletContent.AddComponent<GridLayoutGroup>();
        instanceOngletContent.GetComponent<GridLayoutGroup>().cellSize = new Vector2(500f, 112f);
        instanceOngletContent.AddComponent<ResizeContents>();
        instanceOngletContent.AddComponent<TablModelGO>();
        instanceOngletContent.GetComponent<TablModelGO>().Nom = instanceOngletButton.GetComponentInChildren<TextMeshProUGUI>();
        instanceOngletContent.GetComponent<TablModelGO>().Contenu = new List<Contenu>();
        instanceOngletContent.GetComponent<TablModelGO>().IndexInteraction = i;
        instanceOngletContent.GetComponent<TablModelGO>().IndexOnglet = j;
        interaction.onglets.Add(new Fenetre(j, instanceOngletButton.GetComponentInChildren<TextMeshProUGUI>(), new List<GameObject>()));
    }

    public void AfficherOnglet(int index)
    {
        foreach(Transform child in viewPort.transform)
        {
            if (child.gameObject.activeSelf)
            {
                foreach (Transform chilfOfChild in child)
                {
                    if (chilfOfChild.name.StartsWith("" + index))
                    {
                        chilfOfChild.GetComponent<CanvasGroup>().alpha = 1;
                        foreach (Transform chilfOfChildOfChild in chilfOfChild)
                        {
                            if (chilfOfChildOfChild.name.StartsWith("video"))
                            {
                                chilfOfChildOfChild.GetComponent<VideoPlayer>().Play();
                                chilfOfChildOfChild.GetComponent<VideoPlayer>().Pause();
                            }
                        }
                    } else
                    {
                        chilfOfChild.GetComponent<CanvasGroup>().alpha = 0;
                    }
                }
            }
        }
    }

    public void AjouteContenu(int i, int j, GameObject myObj)
    {
        interactions.Single(it => it.id == i).onglets.Single(on => on.id == j).contenu.Add(myObj);
    }

    public void InstancieNouveauContenu(int interactionIndex, int ongletIndex)
    {
        Interaction interaction = interactions.ElementAt(interactionIndex);
        Fenetre onglet = interaction.onglets.ElementAt(ongletIndex);
    }

    public void RetireInteraction(int index)
    {
        Interaction i = interactions.Single(interaction => interaction.id == index);
     
        GameObject toDestroyTabContainer = ongletPanel.transform.Find(index + "TabContainer(Clone)").gameObject;
        GameObject toDestroyZoneClique = cameraModel.transform.Find(index + "ZoneClick(Clone)").gameObject;
        GameObject toDestroyContentInteraction = viewPort.transform.Find(index + "ContentInteraction(Clone)").gameObject;
        DestroyImmediate(toDestroyTabContainer);
        DestroyImmediate(toDestroyZoneClique);
        DestroyImmediate(toDestroyContentInteraction);
        interactions.Remove(i);
    }

    public void RetireOnglet(int indexInteraction, int indexOnglet)
    {
        Interaction i = interactions.Single(interaction => interaction.id == indexInteraction);
        Fenetre f = i.onglets.Single(fenetre => fenetre.id == indexOnglet);

        GameObject toDestroyTabContent= viewPort.transform.Find(indexInteraction + "ContentInteraction(Clone)").gameObject.transform.Find(indexOnglet+"TabContent(Clone)").gameObject;
        DestroyImmediate(toDestroyTabContent);
        interactions.Single(interaction => interaction.id == indexInteraction).onglets.Remove(f);

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
