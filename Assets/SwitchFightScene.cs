using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SwitchFightScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += ChangeFightScene;
        gameManager = FindAnyObjectByType<GameManager>();      
    }

    void ChangeFightScene(VideoPlayer videoplayer)
    {
        gameManager.ChangeScene(4);
    }
}
