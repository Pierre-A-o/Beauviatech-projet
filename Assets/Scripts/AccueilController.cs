using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccueilController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToModelScene1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void GoToModelScene2()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void GoToModelScene3()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void GoToModelScene4()
    {
        SceneManager.LoadScene("Scene4");
    }
}
