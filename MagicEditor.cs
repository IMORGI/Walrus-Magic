using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MagicEditor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public GameObject spawnElement;
  
    public Transform workPanel;
    public bool mous;
    public bool drag;
    public Vector3 mousePos;
    public Camera camera;
    #region Выбор элемента
    public GameObject fireElement;
    public GameObject waterElement;
    public GameObject airElement;
    public GameObject earthElement;
    private string tagElement;
    public void FireElement()
    {
        spawnElement = fireElement;
    }

    public void WaterElement()
    {
        spawnElement = waterElement;
    }

    public void AirElement()
    {
        spawnElement = airElement;
    }

    public void EarthElement()
    {
        spawnElement = earthElement;
    }
    #endregion  // переделать но пока ок

    private void Start()
    {
        tagElement = fireElement.tag;
        alphpos = workPanel1.transform.position;
    }

    #region bool mous and drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        drag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (tag == tagElement)
        {

          //  eventData.pointerCurrentRaycast.gameObject.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        drag = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mous = true;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mous = false;
    }





    #endregion



    #region Алхимические круги

    public GameObject workPanel1;
    public GameObject alhSpherePrefab;
    public Vector3 alphpos;


   public void SelectionAlhSphere()
    {
        var x = Instantiate(alhSpherePrefab);
        x.transform.SetParent(workPanel1.transform);
        x.transform.position = alphpos;

    }








    #endregion 
    void Update()
    {
       

            #region spawn
            if (Input.GetMouseButtonDown(0) && mous)
            {
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


                // GameObject spawnElementCopy = Instantiate(spawnElement, camera.ScreenToWorldPoint(Input.mousePosition)) + Vector3.forward, Quaternion.identity);
                GameObject spawnElementCopy = (GameObject)Instantiate(spawnElement);
                spawnElementCopy.transform.SetParent(workPanel, false);
                spawnElementCopy.transform.position = transform.position + Vector3.up;


                spawnElementCopy.transform.position = mousePos;

             //   spawnElementCopy.transform.parent = workPanel;

            }
            #endregion
        }

    

}

