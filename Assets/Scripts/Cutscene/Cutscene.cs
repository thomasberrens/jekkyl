using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    private VideoPlayer _videoPlayer;
    void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.Play();
        _videoPlayer.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Room1");//the scene that you want to load after the video has ended.
    }
}
