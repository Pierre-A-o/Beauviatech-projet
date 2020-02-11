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

    public void loadFirstCameraScene(){
          loadScene("FirstCameraScene");
    }

    public void loadSecondCameraScene(){
          loadScene("SecondCameraScene");
    }

    public void loadThirdCameraScene(){
          loadScene("ThirdCameraScene");
    }

    public void loadMicroScene(){
          loadScene("MicroScene");
    }

    private void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
