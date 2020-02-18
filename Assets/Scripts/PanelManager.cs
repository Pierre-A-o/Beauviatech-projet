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
    private bool transitioning;
    private Vector3 transition_goal;
    private Vector3 distanceCameraPanel;
    public GameObject camera;

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
        StartCoroutine(DisparitionPanel());
    }

    public void TransiCameraPanelInterviews()
    {
        camera.SetActive(false);
        transition_goal = PanelInterviews.transform.position + distanceCameraPanel;
        GetComponent<ManipulationController>().isInterviewCurrentScene = true;
        transitioning = true;
    }

    public void TransiCameraPanelModeleScene()
    {
        camera.SetActive(true);
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

