using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    
    public GameObject goodAnswer; 
    private ToggleGroup mytoggleGrp;
    public GameObject myPosFB;
    public GameObject myNegFB;

    private AudioSource correctAudio;
    private AudioSource incorrectAudio;


    public bool isConfirmed = false;
    // Start is called before the first frame update
    
    void Start()
    {
        //access toggle group component
        mytoggleGrp = transform.GetComponent<ToggleGroup>();
        correctAudio = GameObject.Find("AudioCorrect").GetComponent<AudioSource>();
        incorrectAudio = GameObject.Find("AudioIncorrect").GetComponent<AudioSource>();
    }


    

    public void OnConfirmClick()
    {
        
        for (int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).GetComponent<Toggle>())
                {
                    transform.GetChild(i).GetComponent<Toggle>().interactable = false;
                 }
            }
            
        //compare our answer to the correct answer (goodAnswer)
        if(mytoggleGrp.ActiveToggles().FirstOrDefault().gameObject.name == goodAnswer.name)
         {
            
            Debug.Log("correct");
            //enable the positive FB image
            myPosFB.SetActive(true);
            correctAudio.Play();
            GameObject.Find("PanelWordQuiz").GetComponent<QuizManager>().scoreNB = GameObject.Find("PanelWordQuiz").GetComponent<QuizManager>().scoreNB + 1;
         }

        else
        {
            Debug.Log("loser");
            //enable neg FB image
            myNegFB.SetActive(true);
            incorrectAudio.Play();
        }
           
    }
}