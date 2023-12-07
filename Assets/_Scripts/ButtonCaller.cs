using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonCaller : MonoBehaviour
{
    private GameManager gameManager;
    
    
    //At the start of the scene, find any object of type 'GameManager'
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();      
    }

    //Public function which calls the game manager to change scene
    public void SceneCaller(int sceneNumber)
    {
        gameManager.ChangeScene(sceneNumber);
    }
    
    //Function which calls the game manager to quit the game
    public void QuitGame()
    {
        gameManager.Quit();
    }

}
