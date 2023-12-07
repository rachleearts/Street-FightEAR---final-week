using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlot : MonoBehaviour, IDropHandler
{

    //This script is part of the drag and drop quiz scene. It works alongside the DragDrop script.
    public int id;
    private AudioSource correctAudio;
    private AudioSource incorrectAudio; 

    //On awake, find the game objects called audio correct and audio incorrect which contain audio sources
    public void Awake()
    {
        correctAudio = GameObject.Find("AudioCorrect").GetComponent<AudioSource>();
        incorrectAudio = GameObject.Find("AudioIncorrect").GetComponent<AudioSource>();
    }

    //Functions when the text box is dropped into the drop slot.
    public void OnDrop(PointerEventData eventData)
    {
        //If the id of the text box matches the id of the drop slot (ie correct answer):
            //find the QuizHealth script in the PanelPictureQuiz
            //increase the tallyscore variable by one point
            //make the position of the text box the same as the position of the drop slot
            //play the audio to signify correct answer
        if (eventData.pointerDrag.GetComponent<DragDrop>().id == id) 
            {
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().tallyScore = GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().tallyScore + 1;
                Debug.Log("correct");
                eventData.pointerDrag.GetComponent<RectTransform>().transform.position = this.GetComponent<RectTransform>().transform.position;
                correctAudio.Play();
            }

        //If the id of the text box does not match the id of the drop slot (ie incorrect answer)
            //reset the text box to its original position using the DragDrop script ResetPosition function
            //find the QuizHealth script on the PanelPictureQuiz and reduce the tallyscore by one point
            //play the incorrect audio
        else
            {
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().quizHealth = GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().quizHealth - 1; 
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().ChangeBar();
                incorrectAudio.Play();
            }
    }
}
