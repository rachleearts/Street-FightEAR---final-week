using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCaller : MonoBehaviour
{
    
    private GameManager gameManager;
// Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

   public void sceneCaller(int sceneNumber)
    {
        gameManager.ChangeScene(sceneNumber);
        
        
    }
    
}
