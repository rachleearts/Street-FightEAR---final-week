using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Create singleton variable that is static throughout all scenes
    public static GameManager singleton; 
    
    //On awake, singleton pattern commences. If there is is no game manager, keep this one. If there is another game manager, destroy this.
    void Awake() 
    {
        if (singleton == null) 
        {
            singleton = this;
        }
        
        else if (singleton != this) 
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    //Public function: change scene using the scene index number from the build. 
    public void ChangeScene (int sceneIndex) 
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Public function: use this to end the game
    public void Quit() 
    {
        Application.Quit();
    }

}

