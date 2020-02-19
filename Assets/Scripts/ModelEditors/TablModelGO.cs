using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TablModelGO : MonoBehaviour
{
    [HideInInspector]
    public TextMeshProUGUI nom;
    [HideInInspector]
    public List<Contenu> contenu;

    private int indexInteraction;
    private int indexOnglet;


    public void RetireComposant(int index, string element)
    {
        Contenu objet = Contenu.Single(co => co.Id == index);
        Contenu.Remove(objet);
        GameObject toDestroyComposant = gameObject.transform.Find(element + (index + 1)).gameObject;
        DestroyImmediate(toDestroyComposant);
    }

    public int IndexInteraction { get => indexInteraction; set => indexInteraction = value; }
    public int IndexOnglet { get => indexOnglet; set => indexOnglet = value; }
    public TextMeshProUGUI Nom { get => nom; set => nom = value; }
    public List<Contenu> Contenu { get => contenu; set => contenu = value; }
}

[System.Serializable]
public class Contenu
{
    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject objet;

    public Contenu(int id, GameObject objet)
    {
        this.id = id;
        this.objet = objet;
    }

    public int Id { get => id; set => id = value; }
    public GameObject Objet { get => objet; set => objet = value; }
}
