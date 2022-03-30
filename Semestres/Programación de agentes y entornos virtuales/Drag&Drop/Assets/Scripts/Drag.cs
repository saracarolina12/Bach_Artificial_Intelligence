using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IEndDragHandler, IDragHandler, IBeginDragHandler
{
    private RectTransform rect;
    private CanvasGroup group;
    
    public void Awake(){
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("Begin");
        group.alpha = 0.6f;
        group.blocksRaycasts = false; //atraviesa el objeto para que el mouse detecte el de atrás
    }
    public void OnDrag(PointerEventData eventData){
        Debug.Log("Dragging");
        rect.anchoredPosition += eventData.delta/0.6f;
    }
    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("End");
        group.alpha = 1f;
        group.blocksRaycasts = true; //atraviesa el objeto para que el mouse detecte el de atrás
    }
}