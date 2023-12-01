using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropSlot : MonoBehaviour, IDropHandler
{
    public int id;
    private AudioSource correctAudio;
    private AudioSource incorrectAudio; 

    public void Awake()
    {
        correctAudio = GameObject.Find("AudioCorrect").GetComponent<AudioSource>();
        incorrectAudio = GameObject.Find("AudioIncorrect").GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("on drop");
        if (eventData.pointerDrag.GetComponent<DragDrop>().id == id) 
            {
                Debug.Log("correct");
                //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<RectTransform>().transform.position = this.GetComponent<RectTransform>().transform.position;
                correctAudio.Play();
            
            }
        else
            {
                Debug.Log("false");
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().quizHealth = GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().quizHealth - 1; 
                GameObject.Find("PanelPictureQuiz").GetComponent<QuizHealth>().ChangeBar();
                incorrectAudio.Play();
            }
    }
}
