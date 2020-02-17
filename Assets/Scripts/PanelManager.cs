using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public Animator InfoPanelAnimator;
    public float speedTransi = 2;
    public GameObject InfoPanel;
    public GameObject PanelSceneModel;
    public GameObject PanelFilmo;
    public GameObject PanelInterviews;
    public Camera MainCamera;

    private float startTime;
    private float journeyLength;

    private bool transitioning;
    private Vector3 transition_goal;
    private Vector3 distanceCameraPanel;

    // Start is called before the first frame update
    void Start()
    {
        distanceCameraPanel = MainCamera.transform.position - PanelSceneModel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transitioning)
        {
            Transition();
        }
        if (MainCamera.transform.position == transition_goal)
        {
            transitioning = false;
        }
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
    
    public void TransiCameraPanelFilmo()
    {
        transition_goal = PanelFilmo.transform.position + distanceCameraPanel;
        transitioning = true;
    }

    public void TransiCameraPanelInterviews()
    {
        transition_goal = PanelInterviews.transform.position + distanceCameraPanel;
        transitioning = true;
    }

    public void TransiCameraPanelModeleScene()
    {
        transition_goal = PanelSceneModel.transform.position + distanceCameraPanel;
        transitioning = true;
    }

    private void Transition()
    {
        journeyLength = Vector3.Distance(MainCamera.transform.position, transition_goal);
        MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, transition_goal, speedTransi * Time.deltaTime);
    }

    IEnumerator DisparitionPanel()
    {
        InfoPanelAnimator.SetTrigger("Disparition");
        yield return new WaitForSeconds(1);
        InfoPanel.SetActive(false);
    }

}

