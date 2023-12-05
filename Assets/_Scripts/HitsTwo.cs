using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitsTwo : MonoBehaviour
{
    public int totalHit = 1;
    public AudioSource slapCompilation;
    public TestAnimationScript testAnimationScript;


    public GameObject hit1text;
    public GameObject hit2text;
    public GameObject hit3text;
    public GameObject hit4text;
    public GameObject hit5text;
    public GameObject hit6text;
    public GameObject HB0;
    public GameObject HB1;
    public GameObject HB2;
    public GameObject HB3;
    public GameObject HB4;
    public GameObject HB5;
    public GameObject MyCanvas;
    private AudioManager audioManager;

    public Texture2D gloveCursor;
    public RaycastHit hit;

    private bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        testAnimationScript = FindObjectOfType<TestAnimationScript>();
    }


    void Update()
   //only able to interact with gameobject.ear when between the "break" of one case and the start of the next case.
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 600) && hit.collider.gameObject && !isPlaying) //need to put in a constraint for GetMouseButtonDown in order for it to act like onMouseDown. Can not use OMD due to function property.
        {
            Debug.Log("hit");
            StartCoroutine(hits());
            totalHit++;
        }
    }

	private void OnMouseEnter()
    //Cursur changes from mouse to boxing glove when over capsul colider surrounding ear model
	{
        Cursor.SetCursor(gloveCursor, Vector2.zero, CursorMode.Auto);
	}

	private void OnMouseExit()
	{
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}

	IEnumerator hits()
    //start of coroutine
    {
        isPlaying = true;
        switch (totalHit)
        //start of cases that allow for sucessive "hits" to pay out with audio, anim., sprites and panels.
        {
            case 1:
            Debug.Log("hit1");
            hit1text.SetActive(true);
            HB0.SetActive(false);
            HB1.SetActive(true);
            audioManager.SlapAudioTrigger();
            testAnimationScript.EarAnim2();
            //if adio hasnt played bool = false if audio has played bool = true if 
            //fix in audio manager to play random range once 
            break;

            case 2:
            Debug.Log("hit2");
            audioManager.SlapAudioTrigger();
            HB1.SetActive(false);
            HB2.SetActive(true);
            hit1text.SetActive(false);
            hit2text.SetActive(true);
            testAnimationScript.EarAnim3();
            break;
            
            case 3:
            Debug.Log("hit3");
            audioManager.SlapAudioTrigger();
            HB2.SetActive(false);
            HB3.SetActive(true);
            hit2text.SetActive(false);
            hit3text.SetActive(true);
            testAnimationScript.EarAnim4();
            break;

            case 4:
            Debug.Log("hit4");
            audioManager.SlapAudioTrigger();
            HB3.SetActive(false);
            HB4.SetActive(true);
            hit3text.SetActive(false);
            hit4text.SetActive(true);
            testAnimationScript.EarAnim5();
            break;

            case 5:
            Debug.Log("hit5");
            audioManager.SlapAudioTrigger();
            HB4.SetActive(false);
            HB5.SetActive(true);
            hit4text.SetActive(false);
            hit5text.SetActive(true);
            testAnimationScript.EarAnim6();
            break;

            case 6:
            Debug.Log("hit6");
            audioManager.SlapAudioTrigger();
            hit5text.SetActive(false);
            hit6text.SetActive(true);
            testAnimationScript.EarAnim7();
            break;

            case 7:
            Debug.Log("hit7");
            MyCanvas.SetActive(false);
            testAnimationScript.EarAnim8();
            //testAnimationScript.TransitionToEardrum();
            break;

        }
            yield return new WaitForSeconds (1.5f); //int=how long earObj is inactive for player between "hits" 
            isPlaying = false;

            
    }
}
