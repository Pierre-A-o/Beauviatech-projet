using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionMode : MonoBehaviour
{
    [SerializeField]
    private bool Active3D;

    public Button Boutton3D;
    public Button BouttonVR;

    // Start is called before the first frame update
    void Start()
    {
        set3D();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set3D()
    {
        Active3D = true;
        ColorBlock colorDisable = BouttonVR.colors;
        colorDisable.normalColor = Color.black;
        ColorBlock colorSelect = Boutton3D.colors;
        colorSelect.normalColor = Color.red;        
    }

    public void setVR()
    {
        Active3D = false;
        ColorBlock colorDisable = Boutton3D.colors;
        colorDisable.normalColor = Color.black;
        ColorBlock colorSelect = BouttonVR.colors;
        colorSelect.normalColor = Color.red;
    }
}
