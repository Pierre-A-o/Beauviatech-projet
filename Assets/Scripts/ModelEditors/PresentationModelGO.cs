using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PresentationModelGO : MonoBehaviour
{
   [HideInInspector]
    public Image image1;
    [HideInInspector]
    public Image image2;
    [HideInInspector]
    public TextMeshProUGUI text1;
    [HideInInspector]
    public TextMeshProUGUI text2;

    public Sprite spriteImage1;
    public Sprite spriteImage2;
    [HideInInspector]
    public GameObject panelDescription;
    [HideInInspector]
    public GameObject panelExtraitFilm;
    [HideInInspector]
    public GameObject listeDeFilms;
    [HideInInspector]
    public GameObject panelPresentation;

    public Image Image1 { get => image1; set => image1 = value; }
    public Image Image2 { get => image2; set => image2 = value; }
    public TextMeshProUGUI Text1 { get => text1; set => text1 = value; }
    public TextMeshProUGUI Text2 { get => text2; set => text2 = value; }

    
}
