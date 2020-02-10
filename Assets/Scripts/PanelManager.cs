using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public Animator InfoPanelAnimator;
    public Animation AnimationDisparition;
    public GameObject InfoPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retour()
    {
        
        StartCoroutine(DisparitionPanel());
        
    }


    IEnumerator DisparitionPanel()
    {
        InfoPanelAnimator.SetTrigger("Disparition");
        yield return new WaitForSeconds(1);
        InfoPanel.SetActive(false);
       
    }
}

