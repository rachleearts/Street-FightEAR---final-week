using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //Script part of the drag and drop quiz scene. This works alongside the DropSlot script.
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup; 
    public int id; 
    public Vector2 initPosition;

    //On awake, get the rect transform component of the answer text box and the canvas group attached to it
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    //On start, detect current location of the answer text box and call it the initial position
    void Start()
    {
        initPosition = gameObject.transform.position;
    }


    //When the text box is dragged, the raycast is not blocked so that the underlying drop boxes can be identified
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    //when the text box is dragged, it is moved with the cursor position. Keeps scale of the canvas.
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //When the text box is dropped, the raycast is blocked again
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }


    //Placing the text box to its initial position identified in Start()
    public void ResetPosition()
    {
        transform.position = initPosition;
    }

}