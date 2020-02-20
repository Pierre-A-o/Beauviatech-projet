using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClickZoneCliquable : MonoBehaviour
{

    public Ray ray;
    public RaycastHit hit;

    public GameObject FenetreInfo;
    public GameObject viewPort;
    public GameObject ongletPanel;

    // Start is called before the first frame update
    void Start()
    {
        FenetreInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "cliquable")
            {
                FenetreInfo.SetActive(true);
                Debug.Log(hit.collider.name[0]);
                foreach(Transform child in viewPort.transform)
                {
                    if (!child.name.StartsWith("" + hit.collider.name[0]))
                    {
                        child.gameObject.SetActive(false);
                    } else
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                foreach (Transform child in ongletPanel.transform)
                {
                    if (!child.name.StartsWith("" + hit.collider.name[0]))
                    {
                        child.gameObject.SetActive(false);
                    } else
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                GetComponent<ManipulationController>().movingleft = true;
                GetComponent<ManipulationController>().movingright = false;
            }
        }
    }

}
