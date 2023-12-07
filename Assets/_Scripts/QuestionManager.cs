using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    //This script is part of the word quiz scene and works alongside the QuizManager script.
    public GameObject goodAnswer; 
    private ToggleGroup mytoggleGrp;
    public GameObject myPosFB;
    public GameObject myNegFB;
    private AudioSource correctAudio;
    private AudioSource incorrectAudio;
    public bool isConfirmed = false;

    //On Start, the toggle group, the correct audio, and the incorrect audio are found in the scene.
    void Start()
    {
        mytoggleGrp = transform.GetComponent<ToggleGroup>();
        correctAudio = GameObject.Find("AudioCorrect").GetComponent<AudioSource>();
        incorrectAudio = GameObject.Find("AudioIncorrect").GetComponent<AudioSource>();
    }

    //When confirm is clicked
    public void OnConfirmClick()
    { 
        //For loop begins
        for (int i = 0; i < transform.childCount; i++)
        {
            //when confirm is clicked, the toggle buttons can't be clicked
            if(transform.GetChild(i).GetComponent<Toggle>())
            {
                transform.GetChild(i).GetComponent<Toggle>().interactable = false;
            }
        }

        //get the selected toggle name and if it equals the correct answer, display 'correct' image
        //Add one point to the QuizManager under PanelWordQuiz  
        //play incorrect audio
        if(mytoggleGrp.ActiveToggles().FirstOrDefault().gameObject.name == goodAnswer.name)
        {
            myPosFB.SetActive(true);
            correctAudio.Play();
            GameObject.Find("PanelWordQuiz").GetComponent<QuizManager>().scoreNB = GameObject.Find("PanelWordQuiz").GetComponent<QuizManager>().scoreNB + 1;
        }

        //if the selected toggle is not the correct answer, display the 'incorrect' image
        //play incorrect audio
        else
        {
            myNegFB.SetActive(true);
            incorrectAudio.Play();
        }
    }
}