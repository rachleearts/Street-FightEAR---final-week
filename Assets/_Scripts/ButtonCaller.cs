using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCaller : MonoBehaviour
{
    private GameManager gameManager;
    
    //At the start of the scene, find any object of type 'GameManager'
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    //Function which calls the game manager to change scene
    public void SceneCaller(int sceneNumber)
    {
        gameManager.ChangeScene(sceneNumber);
    }
    
    //Function which calls the game manager to quit
    public void QuitGame( )
    {
        gameManager.Quit();
    }
}
