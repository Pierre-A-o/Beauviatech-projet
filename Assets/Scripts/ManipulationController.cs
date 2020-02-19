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

    public bool movingleft;
    public bool movingright;

    private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    private RotationAxes axes = RotationAxes.MouseXAndY;
    private float sensitivityX = 5F;
    private float sensitivityY = 5F;
    private float minimumX = -180F;
    private float maximumX = 180F;
    private float minimumY = -180F;
    private float maximumY = 180F;
    private float rotationX = 0F;
    private float rotationY = 0F;
    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        speedTransi = 2.0f;
        baseScale = Object.transform.localScale;
        myPos = Object.transform.position;
        originalRotation = Object.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pres_panel.activeSelf && !liste_film.activeSelf && !isInterviewCurrentScene)
        {
            ZoomCamera();
            RotateCamera();
        } else
        {
            Object.transform.localScale = baseScale;
            Object.transform.position = myPos;
            myScale = 1.0f;
        }
        if (movingleft)
        {
            MoveLeft();
        }
        if (movingright)
        {
            MoveRight();
        }
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton(0))
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                // Read the mouse input axis
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationX = ClampAngle(rotationX, minimumX, maximumX);
                rotationY = ClampAngle(rotationY, minimumY, maximumY);
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
                Object.transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            }
            else if (axes == RotationAxes.MouseX)
            {
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationX = ClampAngle(rotationX, minimumX, maximumX);
                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
                Object.transform.localRotation = originalRotation * xQuaternion;
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = ClampAngle(rotationY, minimumY, maximumY);
                Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
                Object.transform.localRotation = originalRotation * yQuaternion;
            }
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle <= -360F)
         angle += 360F;
        if (angle >= 360F)
         angle -= 360F;
        return Mathf.Clamp(angle, min, max);
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
        if (!pres_panel.activeSelf && !liste_film.activeSelf && !isInterviewCurrentScene)
        {
            Object.transform.position = Vector3.Lerp(Object.transform.position, cibleLeft.transform.position, speedTransi * Time.deltaTime);
        }
    }

    public void MoveRight()
    {
        if (!pres_panel.activeSelf && !liste_film.activeSelf && !isInterviewCurrentScene)
        {
            Object.transform.position = Vector3.Lerp(Object.transform.position, cibleRight.transform.position, speedTransi * Time.deltaTime);
        }
    }
}
