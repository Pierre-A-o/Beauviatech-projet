using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Video;

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
                foreach (Transform child in viewPort.transform)
                {
                    if (!child.name.StartsWith("" + hit.collider.name[0]))
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                        foreach (Transform chilfOfChild in child)
                        {
                            if (chilfOfChild.name.StartsWith("0"))
                            {
                                chilfOfChild.gameObject.GetComponent<CanvasGroup>().alpha = 1;
                                foreach (Transform childOfChildOfChild in chilfOfChild)
                                {
                                    if (childOfChildOfChild.name.StartsWith("Video"))
                                    {
                                        childOfChildOfChild.GetComponent<VideoPlayer>().Play();
                                        childOfChildOfChild.GetComponent<VideoPlayer>().Pause();
                                    }
                                }
                                } else
                            {
                                chilfOfChild.gameObject.GetComponent<CanvasGroup>().alpha = 0;
                            }

                        }
                    }
                }
                foreach (Transform child in ongletPanel.transform)
                {
                    if (!child.name.StartsWith("" + hit.collider.name[0]))
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                }
                if (GetComponent<HamburgerMenuMovement>().isRevealed)
                {
                    GetComponent<ManipulationController>().movingleft = false;
                    GetComponent<ManipulationController>().movingright = false;
                    GetComponent<ManipulationController>().movingbottom = true;
                } else
                {
                    GetComponent<ManipulationController>().movingleft = true;
                    GetComponent<ManipulationController>().movingright = false;
                    GetComponent<ManipulationController>().movingbottom = false;
                }
            }
        }
    }
}
