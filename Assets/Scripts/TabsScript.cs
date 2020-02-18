using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabsScript : MonoBehaviour
{
    private GameObject instance;
    private List<Tab_Content> contents;

    public Tab_Content currentContent;
    public GameObject displayedTitle;
    public GameObject displayedContent;
    public GameObject tabButton;
    public GameObject buttonList;
    public GameObject scrollBar;


    // Start is called before the first frame update
    void Start()
    {
        InitDefaultTabs();
        InitFirstView();
        InitButtonList();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitDefaultTabs()
    {
        contents = new List<Tab_Content>();
        contents.Add(new Tab_Content
        {
            ContenuText = "Le viseur est un composant intéressant\n\n" + loremIpsum,
            Titre = "Viseur"
        });
        contents.Add(new Tab_Content
        {
            ContenuText = "Le bouton est un composant intéressant\n\n" + loremIpsum,
            Titre = "Bouton"
        });
        contents.Add(new Tab_Content
        {
            ContenuText = "La molette est un composant intéressant\n\n" + loremIpsum,
            Titre = "Molette"
        });
        contents.Add(new Tab_Content
        {
            ContenuText = "Le flash est un composant brillant\n\n" + loremIpsum,
            Titre = "Flash"
        });
    }

    private void InitFirstView()
    {
        currentContent = contents[0];
        ChangeTab(contents[0].Titre);
    }

    private void InitButtonList()
    {
        foreach (Tab_Content content in contents)
        {
            instance = Instantiate(tabButton, buttonList.transform);
            instance.GetComponentInChildren<TextMeshProUGUI>().SetText(content.Titre);
            instance.GetComponent<Button>().image.sprite = Resources.Load<Sprite>("Resources/unity_builtin_extra/UISprite");
            instance.GetComponent<Button>().onClick.AddListener(delegate { ChangeTab(content.Titre); });
        }
    }

    public void ChangeTab(string s)
    {
        currentContent = contents.Find(item => item.Titre.Equals(s));
        displayedTitle.GetComponent<TextMeshProUGUI>().SetText(currentContent.Titre);
        displayedContent.GetComponentInChildren<TextMeshProUGUI>().text = currentContent.ContenuText;
        scrollBar.GetComponent<Scrollbar>().value = 1;
    }

    private string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Morbi tempor ornare fermentum.Vivamus purus elit, cursus id massa ac, tincidunt sodales metus.Ut volutpat sapien eget suscipit scelerisque. Curabitur auctor pharetra auctor. Donec tellus nulla, euismod a blandit vel, egestas sit amet velit. Phasellus auctor purus et eleifend dapibus. Suspendisse lorem nulla, sagittis vitae lacus eget, pharetra elementum justo.Pellentesque id lectus purus. \n\nDuis sit amet dui lectus.Nullam quis metus a eros mollis commodo.Nunc faucibus fringilla ante, ut dignissim magna viverra vel.Cras laoreet, ligula at mollis tempus, mi erat vestibulum neque, a gravida arcu diam ut dolor. Aenean vestibulum cursus enim, ut semper leo bibendum gravida.Quisque faucibus, ipsum sit amet feugiat scelerisque, turpis odio porta ipsum, eu porta augue diam eu lacus. Integer varius in ex semper eleifend.Nunc a tristique lorem. Nullam bibendum volutpat sapien sed tempor. Quisque magna ex, tempus a mi vel, pulvinar laoreet sem.Nunc ut mollis ipsum. Nulla pellentesque placerat eros in tincidunt.Morbi congue molestie est ac rutrum. Nulla ut orci in ex rhoncus egestas.Fusce nec consequat est. Sed rhoncus eleifend elementum. Fusce quam augue, gravida sit amet ultricies a, porttitor quis est.Nulla ac sodales nulla. \n\nMaecenas nec suscipit diam, ac suscipit nibh.Ut consectetur lacus a nibh interdum, in hendrerit mi maximus.Nullam ultrices sem vel maximus lobortis. Sed tempor posuere arcu, nec luctus libero accumsan sed.Nulla volutpat lorem tortor, eget ornare massa convallis ac.Nullam non arcu vel felis aliquam rhoncus in et arcu. Vestibulum condimentum euismod risus, vitae dapibus libero pharetra nec.Nunc tempus fermentum nisi, vitae accumsan felis porttitor in. Mauris dapibus a turpis ac convallis. Integer rutrum ligula eget ante gravida, quis tempus orci consequat.";
}
