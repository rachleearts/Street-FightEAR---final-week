using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionVidEarDrum : MonoBehaviour
//SCRIPT CALLED WHEN NEXT ARROW IS CLICKED ON THE EARDRUM SCENE. CONTROLS EARDRUM SCENE.
{

    public GameObject videoPanel;
    public GameObject textPanel1;
    public GameObject textPanel2;
    public GameObject punchButton;
    public Animator earDrumTear;
    public AudioSource tearTinAudio;
    
    public void PlayCoroutine()
    //Coroutine below starts. The punch button becomes inactive.
    {
        StartCoroutine(TransitionVideoTear());
        punchButton.SetActive(false);
    }
        
    IEnumerator TransitionVideoTear()
    //all UI panels set inactive
    //set the video panel active which plays the 2D animation
    //after 4 seconds, set the animation inactive and play the ear drum tear animation / tinnitus audio
    {
        videoPanel.SetActive(true);
        textPanel1.SetActive(false);
        textPanel2.SetActive(true);

        yield return new WaitForSeconds(4f);

        videoPanel.SetActive(false);
        earDrumTear.SetTrigger("play_eardrum_tear");
        tearTinAudio.Play();


    }
}
