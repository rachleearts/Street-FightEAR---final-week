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

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //initPosition = transform.position;
    }
    //Detect current clicks on the GameObject (the one with the script attached)

    void Start()
    {
        initPosition = gameObject.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("on begin drag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on drag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("on end drag");
        canvasGroup.blocksRaycasts = true;
    }

    public void ResetPosition()
    {
        transform.position = initPosition;
    }

}