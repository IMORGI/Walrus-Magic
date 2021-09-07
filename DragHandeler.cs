using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    public GameObject element;


    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        
        startPosition = transform.position;
        startParent = transform.parent;
      //  GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; //ДОБАВИТЬ БЛОКИРОВКУ ПО Z
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
      //  GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent != startParent)
        {
            
                transform.position = startPosition;
            
        }
        
        
    }

    #region Попытка вернуть обьект назад после использования
    #endregion


}
