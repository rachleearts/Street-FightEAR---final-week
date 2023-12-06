using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionVidEarDrum : MonoBehaviour
{

    public GameObject videoPanel;
    public Animator earDrumTear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void PlayCoroutine()
    {
        StartCoroutine(TransitionVideoTear());
    }
        
    // Update is called once per frame
    IEnumerator TransitionVideoTear()
    {
        videoPanel.SetActive(true);

        yield return new WaitForSeconds(4f);

        videoPanel.SetActive(false);
        //earDrumTear.Play();
        earDrumTear.SetTrigger("play_eardrum_tear");
    }
        
        //function1(exe)
        //fucntion2(exe)

        //void function1


}
