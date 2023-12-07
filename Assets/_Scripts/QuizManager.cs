
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    //This script is part of the word quiz scene and works alongside the QuestionManager script.
    public List<GameObject> myListOfQuestions = new List<GameObject>();

    public int maxNBQuestions = 5;
    private GameObject myCurrentQuestion;
    private int counter;

    public GameObject myFinalPanel;

    public int scoreNB = 0;

    public Animator wellDone;
    public Animator notQuite; 
    public GameObject btnHelp;
    public GameObject btnMenu;
    public GameObject btnStart;
    public GameObject panelOne;
    public GameObject panelTwo;
    public GameObject panelThree;
    public GameObject panelFour;
    public GameObject panelFive;
    public GameObject panelSix;


    //On start, random question is displayed and the list of questions reduces by one (ie question cant be played twice)
    void Start()
    {
        counter = Random.Range(0,myListOfQuestions.Count-1);
        myCurrentQuestion = myListOfQuestions[counter];
        myCurrentQuestion.SetActive(true);
    }

    //When the next button is clicked on the question, the total number of questions reduces by one (out of 5)
    public void OnNextBtnClick()
    {
        maxNBQuestions = maxNBQuestions - 1;

        //If all five questions haven't displayed, remove the current question from the list and display another
        if(maxNBQuestions > 0)
        {
            myCurrentQuestion.SetActive(false);
            myListOfQuestions.RemoveAt(counter);
            counter = Random.Range(0,myListOfQuestions.Count-1);
            myCurrentQuestion = myListOfQuestions[counter];
            myCurrentQuestion.SetActive(true);
        }

        //If all five questions have been displayed, set the results panel active
        //Get the text component of that panel and display the score 
        else
        {
            Debug.Log("game over");
            myCurrentQuestion.SetActive(false);
            myFinalPanel.SetActive(true);
            myFinalPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = myFinalPanel.transform.GetChild(0).GetComponent<TMP_Text>().text + scoreNB;
            btnHelp.SetActive(false);
            btnStart.SetActive(false);
            btnMenu.SetActive(false);
            panelFive.SetActive(false);
            panelFour.SetActive(false);
            panelThree.SetActive(false);
            panelTwo.SetActive(false);
            panelOne.SetActive(false);
            panelSix.SetActive(false);

            //If the final score is >4, show the happy animation on the result panel
            if( scoreNB > 4) 
            {   
             wellDone.SetBool("play_score5", false);
            }

            //If the final score <4, show the shock animation on the result panel
            else
            {
                notQuite.SetBool("play_score4", false );
            }
        
        }
       
    }
}
