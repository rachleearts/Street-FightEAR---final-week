using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizHealth : MonoBehaviour
{
    public int quizHealth = 4;

    public int tallyScore = 0;
    public GameObject highhealthBar;
    public GameObject mediumhealthBar;
    public GameObject lowhealthBar;
    public GameObject finalPanel;

    private GameObject submitButton;

    public GameObject welcomeText;
    public GameObject welcomeInstructions;
    public GameObject quizMenu;
    public GameObject startMenu;

    public Animator wellDone;
    public Animator notQuite; 
  

    public void ChangeBar()
        {
            Debug.Log("quiz health begins");
                    switch (quizHealth)
                    {
                     case 4:
                        highhealthBar.SetActive(true);
                        break;
                     case 3:
                        highhealthBar.SetActive(false);
                        mediumhealthBar.SetActive(true);
                        break;

                     case 2:
                        mediumhealthBar.SetActive(false);
                        lowhealthBar.SetActive(true);
                        break;
            
                     case 1:
                        lowhealthBar.SetActive(false);
                        finalPanel.SetActive(true);
                        //notQuite = GameObject.Find("TxtNotQuite");
                        //notQuite.SetActive(true);
                        //wellDone = GameObject.Find("TxtWellDone");
                        //wellDone.SetActive(false);
                        GameObject.Find("PanelEarPicture").SetActive(false);
                        submitButton = GameObject.Find("BtnConfirm");
                        submitButton.SetActive(false);

                        welcomeText.SetActive(false);
                        startMenu.SetActive(false);
                        quizMenu.SetActive(false);
                        welcomeInstructions.SetActive(false);

                        notQuite.SetBool("play_score4",false);

                        break;
                    }
        }
      
      public void OnClick()
      {

         if (tallyScore > 4)
         {
            GameObject.Find("PanelEarPicture").SetActive(false);

            submitButton = GameObject.Find("BtnConfirm");
            submitButton.SetActive(false);

            finalPanel.SetActive(true);

            //wellDone = GameObject.Find("TxtWellDone");
            //wellDone.SetActive(true);

            //notQuite = GameObject.Find("TxtNotQuite");
            //notQuite.SetActive(false);

            lowhealthBar.SetActive(false);
            mediumhealthBar.SetActive(false);
            highhealthBar.SetActive(false);

            welcomeText.SetActive(false);
            startMenu.SetActive(false);
            quizMenu.SetActive(false);
            welcomeInstructions.SetActive(false);

            wellDone.SetBool("play_score5",false);
         }

         else
         {
            GameObject.Find("PanelEarPicture").SetActive(false);
            
            finalPanel.SetActive(true);

            //notQuite = GameObject.Find("TxtNotQuite");
            //notQuite.SetActive(true);

            //wellDone = GameObject.Find("TxtWellDone");
            //wellDone.SetActive(false);
            
            lowhealthBar.SetActive(false);
            mediumhealthBar.SetActive(false);
            highhealthBar.SetActive(false);

            submitButton = GameObject.Find("BtnConfirm");
            submitButton.SetActive(false);

            welcomeText.SetActive(false);
            startMenu.SetActive(false);
            quizMenu.SetActive(false);
            welcomeInstructions.SetActive(false);

            notQuite.SetBool("play_score4",false);
         }
      }




     
}
