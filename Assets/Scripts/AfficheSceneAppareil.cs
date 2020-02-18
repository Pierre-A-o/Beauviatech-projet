using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfficheSceneAppareil : MonoBehaviour
{

    public Object SceneACharger;

    public GestionMode bool3D;

    public void afficherScene(Object SceneACharger)
    {
        if (bool3D.Active3D)
        {
            SceneManager.LoadScene(SceneACharger.name);
        }
        else
        {
            //Load VR
        }

        
    }

}
