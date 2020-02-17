using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfficheSceneAppareil : MonoBehaviour
{

    public Object SceneACharger;
   
    public void afficherScene(Object SceneACharger)
    {
        SceneManager.LoadScene(SceneACharger.name);
    }

}
