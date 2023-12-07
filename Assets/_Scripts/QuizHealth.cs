using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizHealth : MonoBehaviour
{
   //This script is associated to the picture quiz scene. It monitors the progess of the player through a health bar.
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
    public GameObject panelOne;
    public GameObject panelTwo;
    public GameObject panelThree;
    public GameObject panelFour;
    public GameObject panelFive;
    public GameObject panelSix;

    public Animator wellDone;
    public Animator notQuite; 
  
   //Switch case: as the quiz health reduces by one (starting at four), the health bar goes down.
   //When the quiz health reaches zero, the panel switches to the result panel and the shock face animation plays
    public void ChangeBar()
        {
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
                  GameObject.Find("PanelEarPicture").SetActive(false);
                  submitButton = GameObject.Find("BtnConfirm");
                  submitButton.SetActive(false);
                  welcomeText.SetActive(false);
                  startMenu.SetActive(false);
                  quizMenu.SetActive(false);
                  welcomeInstructions.SetActive(false);
                  panelFive.SetActive(false);
                  panelFour.SetActive(false);
                  panelThree.SetActive(false);
                  panelTwo.SetActive(false);
                  panelOne.SetActive(false);
                  panelSix.SetActive(false);
                  notQuite.SetBool("play_score4",false);
                  break;
            }
        }
      
      //When the confirm button is clicked
      public void OnClick()
      {
         //If the tally score of the quiz is >4 (ie all correct), the final panel becomes active and the happy animation plays
         if (tallyScore > 4)
         {
            GameObject.Find("PanelEarPicture").SetActive(false);

            submitButton = GameObject.Find("BtnConfirm");
            submitButton.SetActive(false);
            finalPanel.SetActive(true);
            lowhealthBar.SetActive(false);
            mediumhealthBar.SetActive(false);
            highhealthBar.SetActive(false);
            welcomeText.SetActive(false);
            startMenu.SetActive(false);
            quizMenu.SetActive(false);
            welcomeInstructions.SetActive(false);
            panelFive.SetActive(false);
            panelFour.SetActive(false);
            panelThree.SetActive(false);
            panelTwo.SetActive(false);
            panelOne.SetActive(false);
            panelSix.SetActive(false);
            wellDone.SetBool("play_score5",false);
         }
         
         //If the tally score is <4, the final panel becomes active and the shock animation plays
         else
         {
            GameObject.Find("PanelEarPicture").SetActive(false);
            finalPanel.SetActive(true);
            lowhealthBar.SetActive(false);
            mediumhealthBar.SetActive(false);
            highhealthBar.SetActive(false);
            submitButton = GameObject.Find("BtnConfirm");
            submitButton.SetActive(false);
            welcomeText.SetActive(false);
            startMenu.SetActive(false);
            quizMenu.SetActive(false);
            welcomeInstructions.SetActive(false);
            panelFive.SetActive(false);
            panelFour.SetActive(false);
            panelThree.SetActive(false);
            panelTwo.SetActive(false);
            panelOne.SetActive(false);
            panelSix.SetActive(false);
            notQuite.SetBool("play_score4",false);
         }
      }




     
}
