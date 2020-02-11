using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extrait_Film
{
    private string nom_film;
    private string nom_miniature;
    private string description;

    public string Description { get => description; set => description = value; }
    public string Nom_film { get => nom_film; set => nom_film = value; }
    public string Nom_miniature { get => nom_miniature; set => nom_miniature = value; }
}
