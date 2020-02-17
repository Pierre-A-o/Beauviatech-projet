using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfficheSceneAppareil : MonoBehaviour
{

    public Object SceneACharger;

    private bool Active3D;
    private bool ActiveVR;

    public void afficherScene(Object SceneACharger)
    {
        SceneManager.LoadScene(SceneACharger.name);
    }

}
