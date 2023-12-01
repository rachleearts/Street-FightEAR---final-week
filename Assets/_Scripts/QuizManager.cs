
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<GameObject> myListOfQuestions = new List<GameObject>();

    public int maxNBQuestions = 5;
    private GameObject myCurrentQuestion;
    private int counter;

    public GameObject myFinalPanel;

    public int scoreNB = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        //at init, activate one Q from list randomly from 0 to max which is count-1
        counter = Random.Range(0,myListOfQuestions.Count-1);
        myCurrentQuestion = myListOfQuestions[counter];
        myCurrentQuestion.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNextBtnClick()
    {
        maxNBQuestions = maxNBQuestions - 1;

        if(maxNBQuestions > 0)
        {
            //disable question
            myCurrentQuestion.SetActive(false);
            //remove questoin from list
            myListOfQuestions.RemoveAt(counter);
            
            

            counter = Random.Range(0,myListOfQuestions.Count-1);
            myCurrentQuestion = myListOfQuestions[counter];
            myCurrentQuestion.SetActive(true);
        }

        else
        {
            Debug.Log("game over");
            myCurrentQuestion.SetActive(false);

            myFinalPanel.SetActive(true);

            //update final score

            myFinalPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = myFinalPanel.transform.GetChild(0).GetComponent<TMP_Text>().text + scoreNB;

        }
    }
}
