using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationController : MonoBehaviour
{
    public float speed = 2f;
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButton(0))
         {
             Object.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
         }
    }
}
