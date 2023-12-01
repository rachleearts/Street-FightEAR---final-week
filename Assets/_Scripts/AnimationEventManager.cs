using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    
    private HitsTwo HitsTwo;
    
    // Start is called before the first frame update
    void Start()
    {
        HitsTwo = FindObjectOfType<HitsTwo>();

        HitsTwo.enabled = false;
    }

    public void EnableHitsScript()
    {
        Debug.Log("Enabled");
        HitsTwo.enabled = true;

    }
}
