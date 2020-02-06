using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class interviews : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Button retourAccueilBoutton;
    public Button fermerPage;

    public int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        rawImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LanceVideoClick()
    {
        StartCoroutine("LanceVideo", id);
    }

    public void RetourAccueil()
    {
        SceneManager.LoadScene("PAScene");
    }

    public void FermerFenêtre()
    {
        rawImage.enabled = false;
        retourAccueilBoutton.enabled = true;
        fermerPage.enabled = false;
    }

    IEnumerable LanceVideo(int id)
    {
        rawImage.enabled = true;
        retourAccueilBoutton.enabled = false;
        fermerPage.enabled = true;
        videoPlayer.Prepare();
        WaitForSeconds attente = new WaitForSeconds(1);
        while(videoPlayer.isPrepared)
        {
            yield return attente;
            break; 
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
