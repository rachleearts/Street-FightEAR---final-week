using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionVidEarDrum : MonoBehaviour
{

    public GameObject videoPanel;
    public GameObject textPanel1;
    public GameObject textPanel2;
    public GameObject punchButton;
    public Animator earDrumTear;
    public AudioSource tearTinAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void PlayCoroutine()
    {
        StartCoroutine(TransitionVideoTear());
        punchButton.SetActive(false);
    }
        
    // Update is called once per frame
    IEnumerator TransitionVideoTear()
    {
        videoPanel.SetActive(true);
        textPanel1.SetActive(false);
        textPanel2.SetActive(true);

        yield return new WaitForSeconds(4f);
        Debug.Log("4s over");

        videoPanel.SetActive(false);
        //earDrumTear.Play();
        
        earDrumTear.SetTrigger("play_eardrum_tear");
        tearTinAudio.Play();


    }
        
        //function1(exe)
        //fucntion2(exe)

        //void function1


}
