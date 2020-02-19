using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestionMode : MonoBehaviour
{
    public bool Active3D;

    public Button Boutton3D;
    public Button BouttonVR;

    public Color actif;
    public Color inactif;

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
        colorDisable.normalColor = inactif;
        BouttonVR.colors = colorDisable;
        ColorBlock colorSelect = Boutton3D.colors;
        colorSelect.normalColor = actif;
        Boutton3D.colors = colorSelect;
    }

    public void setVR()
    {
        Active3D = false;
        ColorBlock colorDisable = Boutton3D.colors;
        colorDisable.normalColor = inactif;
        Boutton3D.colors = colorDisable;
        ColorBlock colorSelect = BouttonVR.colors;
        colorSelect.normalColor = actif;
        BouttonVR.colors = colorSelect;
    }
}