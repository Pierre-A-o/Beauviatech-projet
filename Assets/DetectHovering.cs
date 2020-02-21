using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHovering : MonoBehaviour
{
    public GameObject UIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("je suis sur infopanel");
        UIManager.GetComponent<ManipulationController>().pointingOnInfopanel = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("je suis pas sur infopanel");
        UIManager.GetComponent<ManipulationController>().pointingOnInfopanel = false;
    }
}
