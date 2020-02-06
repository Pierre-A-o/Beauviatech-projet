using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interviews : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LanceVideo(id));
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetourAccueil()
    {
    
    }

    IEnumerable LanceVideo(int id)
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(videoPlayer.isPrepared)
        {
      
 
        }
    }
}
