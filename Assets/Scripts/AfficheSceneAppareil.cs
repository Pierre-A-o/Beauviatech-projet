using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfficheSceneAppareil : MonoBehaviour
{

    public GestionMode bool3D;

    public void afficherScene()
    {
        if (bool3D.Active3D)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            //Load VR
        }

        
    }

}
