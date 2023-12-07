using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SwitchFightScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private GameManager gameManager;

    //On Start, find the game manager.
    //When the end of the video is reached, do ChangeFigthScene function
    void Start()
    {
        videoPlayer.loopPointReached += ChangeFightScene;
        gameManager = FindAnyObjectByType<GameManager>();      
    }

    //Call the game manager to change scene at the end of the video
    void ChangeFightScene(VideoPlayer videoplayer)
    {
        gameManager.ChangeScene(3);
    }
}
