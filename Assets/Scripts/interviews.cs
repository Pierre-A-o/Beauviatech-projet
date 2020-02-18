using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class interviews : MonoBehaviour
{
    public GameObject rawImageGameObject;
    public VideoPlayer videoPlayer;
    public GameObject retourAccueilBoutton;
    public GameObject listVideos;

    public List<string> test;

    public int id = 0;
    private RawImage image;

    public object EventUnityEngine { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rawImageGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LanceVideoClick()
    {
        retourAccueilBoutton.SetActive(false);
        listVideos.SetActive(false);
        rawImageGameObject.SetActive(true);
    }

    public void RetourAccueil()
    {
        //TODO Effectuer un changement dynamique à la place
        SceneManager.LoadScene("FirstCameraScene");
    }

    public void FermerFenêtre()
    {
        rawImageGameObject.SetActive(false);
        retourAccueilBoutton.SetActive(true);
        listVideos.SetActive(true);
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        } else
        {
            videoPlayer.Play();
        }
    }

   
}
