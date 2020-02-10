using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class AjoutPrefabs : MonoBehaviour
{
    public GameObject videoPrefab;
    public List<VideoPlayer> listVideo;


    // Current components
  
    private GameObject current_Obj;
    // Start is called before the first frame update
    void Start()
    {
        /*foreach (VideoPlayer v in listVideo) {
            current_Obj = Instantiate(videoPrefab);
            current_Obj.GetComponent<TextMeshPro>().SetText("");

   
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
