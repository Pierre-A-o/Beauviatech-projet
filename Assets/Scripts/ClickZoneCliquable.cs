using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZoneCliquable : MonoBehaviour
{

    public Ray ray;
    public RaycastHit hit;

    public GameObject FenetreInfo;

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
                print(hit.collider.name);
                FenetreInfo.SetActive(true);
            }
        }
    }

}
