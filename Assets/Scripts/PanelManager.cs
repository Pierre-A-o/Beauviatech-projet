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
    public GameObject PanelInterviews;
    public Camera MainCamera;
    private bool transitioning;
    private Vector3 transition_goal;
    private Vector3 distanceCameraPanel;
    public GameObject myCamera;

    // Start is called before the first frame update
    void Start()
    {
        distanceCameraPanel = MainCamera.transform.position - PanelSceneModel.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCamera.transform.position == transition_goal)
        {
            transitioning = false;
        }
        if (transitioning)
        {
            Transition();
        }
    }

    public void DisparitionP()
    {
        GetComponent<ManipulationController>().movingbottom = false;
        GetComponent<ManipulationController>().movingleft = false;
        GetComponent<ManipulationController>().movingright = true;
        StartCoroutine(DisparitionPanel());
    }

    public void TransiCameraPanelInterviews()
    {
        if (!InfoPanel.activeSelf)
        {
            GetComponent<FilmoController>().GoToPrincipal();
            myCamera.SetActive(false);
            transition_goal = PanelInterviews.transform.position + distanceCameraPanel;
            GetComponent<ManipulationController>().isInterviewCurrentScene = true;
            transitioning = true;
        }
    }

    public void TransiCameraPanelModeleScene()
    {
        myCamera.SetActive(true);
        transition_goal = PanelSceneModel.transform.position + distanceCameraPanel;
        GetComponent<ManipulationController>().isInterviewCurrentScene = false;
        transitioning = true;
    }

    private void Transition()
    {
        MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, transition_goal, speedTransi * Time.deltaTime);
    }

    IEnumerator DisparitionPanel()
    {
        InfoPanelAnimator.SetTrigger("Disparition");
        yield return new WaitForSeconds(1);
        InfoPanel.SetActive(false);
    }

}

