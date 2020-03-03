using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMenu : MonoBehaviour
{
    void Start()
    {
    }

    void Update(){}

    public void loadAccueil()
    {
        loadScene("Accueil");
    }
    public void loadFirstCameraScene(){
          loadScene("Scene1");
    }

    public void loadSecondCameraScene(){
          loadScene("Scene2");
    }

    public void loadThirdCameraScene(){
          loadScene("Scene3");
    }

    public void loadMicroScene(){
          loadScene("Scene4");
    }

    private void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
