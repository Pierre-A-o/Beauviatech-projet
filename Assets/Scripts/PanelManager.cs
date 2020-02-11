using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void DisparitionP()
    {
        StartCoroutine(DisparitionPanel());
    }

    public void Filmo()
    {
        SceneManager.LoadScene("Filmographie");
    }

    public void Interview()
    {
        SceneManager.LoadScene("InterviewScene");
    }


    IEnumerator DisparitionPanel()
    {
        InfoPanelAnimator.SetTrigger("Disparition");
        yield return new WaitForSeconds(1);
        InfoPanel.SetActive(false);
          
    }
}

