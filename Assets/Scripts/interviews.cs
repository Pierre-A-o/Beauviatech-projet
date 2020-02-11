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

    public int id = 0;
    private RawImage image;

    public object EventUnityEngine { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rawImageGameObject.active = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LanceVideoClick()
    {
        // récupérer image
        image = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentInParent<RawImage>();
        StartCoroutine("LanceVideo");
    }

    public void RetourAccueil()
    {
        //TODO Effectuer un changement dynamique à la place
        SceneManager.LoadScene("PAScene");
    }

    public void FermerFenêtre()
    {
        rawImageGameObject.active = false;
        retourAccueilBoutton.active = true;
        listVideos.active = true;
    }

    IEnumerator LanceVideo()
    {
        rawImageGameObject.GetComponent<RawImage>().texture = image.texture;
        rawImageGameObject.active = true;
        retourAccueilBoutton.active = false;
        listVideos.active = false;
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
