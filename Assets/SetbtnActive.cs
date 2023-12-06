using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetbtnActive : MonoBehaviour
{
    public GameObject buttonPerf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void AnimTrigger()
    {
        buttonPerf.SetActive(true);
    }
}
