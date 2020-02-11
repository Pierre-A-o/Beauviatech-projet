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
    public AudioSource audioSource;
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
        image = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<RawImage>();
        StartCoroutine("LanceVideo");
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

    IEnumerator LanceVideo()
    {
        rawImageGameObject.GetComponent<RawImage>().texture = image.texture;
        rawImageGameObject.SetActive(true);
        retourAccueilBoutton.SetActive(false);
        listVideos.SetActive(false);
        // videoPlayer.Prepare();
        WaitForSeconds attente = new WaitForSeconds(1);
        /*while(videoPlayer.isPrepared)
        {
            yield return attente;
            break; 
        }*/
        /*videoPlayer.Play();
        audioSource.Play();*/
        yield return attente;
        StopCoroutine("LanceVideo");
    }
}
