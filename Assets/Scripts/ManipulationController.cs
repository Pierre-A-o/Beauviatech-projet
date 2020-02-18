using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationController : MonoBehaviour
{
    public float speed = 2f;
    public GameObject Object;
    public GameObject cibleLeft;
    public GameObject cibleRight;

    public GameObject pres_panel;
    public GameObject liste_film;
    public GameObject info_panel;
    public bool isInterviewCurrentScene;

    private Vector3 baseScale;
    private Vector3 myPos;
    private float speedTransi;
    private float myScale = 1.0f;
    float smooth = 5.0f;
    public float AngleDeRotationMaximal = 160.0f;

    // Start is called before the first frame update
    void Start()
    {
        speedTransi = 2.0f;
        baseScale = Object.transform.localScale;
        myPos = Object.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pres_panel.activeSelf && !liste_film.activeSelf && !isInterviewCurrentScene)
        {
            if (info_panel.activeSelf)
            {
                MoveLeft();
            }
            else
            {
                MoveRight();
            }
            ZoomCamera();
            RotateCamera();
        } else
        {
            Object.transform.localScale = baseScale;
            Object.transform.position = myPos;
            myScale = 1.0f;
        }
    }

    private void RotateCamera()
    {
        // Dampen towards the target rotation
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
        {
            float tiltAroundX = -Input.GetAxis("Vertical") * AngleDeRotationMaximal;
            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);
            Object.transform.rotation = Quaternion.Slerp(Object.transform.rotation, target, Time.deltaTime * smooth);
        } else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float tiltAroundY = Input.GetAxis("Horizontal") * AngleDeRotationMaximal;
            Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);
            Object.transform.rotation = Quaternion.Slerp(Object.transform.rotation, target, Time.deltaTime * smooth);
        }
    }

    private void ZoomCamera()
    {
        myScale += Input.GetAxis("Mouse ScrollWheel");
        if(myScale > 2.0f)
        {
            myScale = 2.0f;
        } else if(myScale < 0.5f)
        {
            myScale = 0.5f;
        } else
        {
            Object.transform.localScale *= (1 + Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    public void MoveLeft()
    {
        Object.transform.position = Vector3.Lerp(Object.transform.position, cibleLeft.transform.position, speedTransi * Time.deltaTime);
    }

    public void MoveRight()
    {
        Object.transform.position = Vector3.Lerp(Object.transform.position, cibleRight.transform.position, speedTransi * Time.deltaTime);
    }
}
