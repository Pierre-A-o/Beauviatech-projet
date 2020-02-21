using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PresentationModelGO : MonoBehaviour
{
   
    public Image image1;
 
    public Image image2;
    
    public TextMeshProUGUI text1;
   
    public TextMeshProUGUI text2;

    public Sprite spriteImage1;
    public Sprite spriteImage2;
    public GameObject panelDescription;
    public GameObject panelExtraitFilm;

    public GameObject listeDeFilms;
    public GameObject panelPresentation;

    public Image Image1 { get => image1; set => image1 = value; }
    public Image Image2 { get => image2; set => image2 = value; }
    public TextMeshProUGUI Text1 { get => text1; set => text1 = value; }
    public TextMeshProUGUI Text2 { get => text2; set => text2 = value; }

    
}
