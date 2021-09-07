using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("����� �� ������");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("���� ������");
      //  canvasGroup.alpha = .6f;
       // canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("���� ������");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�������� ������");
       // canvasGroup.alpha = 1f;
        //canvasGroup.blocksRaycasts = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("������ ������");
    }
}
