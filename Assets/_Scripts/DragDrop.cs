using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
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


    //When the text box is dragged, 
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("on end drag");
        canvasGroup.blocksRaycasts = true;
    }


    //Placing the text box to its initial position identified in Start()
    public void ResetPosition()
    {
        transform.position = initPosition;
    }

}