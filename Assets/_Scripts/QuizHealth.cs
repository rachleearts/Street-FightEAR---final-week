using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuizHealth : MonoBehaviour
{
    public int quizHealth = 4;
    public GameObject highhealthBar;
    public GameObject mediumhealthBar;
    public GameObject lowhealthBar;
    public GameObject finalPanel;

    private GameObject notQuite;
    private GameObject wellDone;

    private GameObject submitButton;


   
  

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
                        notQuite = GameObject.Find("TxtNotQuite");
                        notQuite.SetActive(true);
                        wellDone = GameObject.Find("TxtWellDone");
                        wellDone.SetActive(false);
                        GameObject.Find("PanelEarOne").SetActive(false);
                        submitButton = GameObject.Find("BtnSubmit");
                        submitButton.SetActive(false);
                        break;
                    }
        }
      
      public void OnClick()
      {
         if (quizHealth > 3)
         {
            GameObject.Find("PanelEarOne").SetActive(false);

            submitButton = GameObject.Find("BtnSubmit");
            submitButton.SetActive(false);

            finalPanel.SetActive(true);

            wellDone = GameObject.Find("TxtWellDone");
            wellDone.SetActive(true);

            notQuite = GameObject.Find("TxtNotQuite");
            notQuite.SetActive(false);

            lowhealthBar.SetActive(false);
            mediumhealthBar.SetActive(false);
            highhealthBar.SetActive(false);
         }

         else
         {
            GameObject.Find("PanelEarOne").SetActive(false);
            
            finalPanel.SetActive(true);

            notQuite = GameObject.Find("TxtNotQuite");
            notQuite.SetActive(true);

            wellDone = GameObject.Find("TxtWellDone");
            wellDone.SetActive(false);
            
            lowhealthBar.SetActive(false);
            mediumhealthBar.SetActive(false);
            highhealthBar.SetActive(false);

            submitButton = GameObject.Find("BtnSubmit");
            submitButton.SetActive(false);
         }
      }
}
