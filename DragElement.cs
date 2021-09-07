using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    [SerializeField] private Image mainImage;
    public GameObject spawnElement;
    private Material mainMaterial;
    /// <summary>
    /// Материал, применяемый к объектам на сцене
    /// </summary>
    public Material MainMaterial
    {
        get { return mainMaterial; }
        set
        {
            if (value != null)
            {
                mainMaterial = value;
                if (mainImage != null)
                    mainImage.color = mainMaterial.color;
            }
        }
    }

    private Transform defaultParentTransform;
    /// <summary>
    /// Трансформ объекта, к которому прикреплена кнопка
    /// </summary>
    public Transform DefaultParentTransform
    {
        get { return defaultParentTransform; }
        set
        {
            if (value != null)
            {
                defaultParentTransform = value;
            }
        }
    }

    private Transform dragParentTransform;
    /// <summary>
    /// Трансформ объекта, к которому прикрепляется кнопка во время драга
    /// </summary>
    public Transform DragParentTransform
    {
        get
        {
            return dragParentTransform;
        }
        set
        {
            if (value != null)
                dragParentTransform = value;
        }
        
    }

    
   


    private int siblingIndex;
    /// <summary>
    /// Номер индекса внутри родительского объекта
    /// </summary>
    public int SiblingIndex
    {
        get { return siblingIndex; }
        set
        {
            if (value > 0)
                siblingIndex = value;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(DragParentTransform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }


    #region mous

    public bool mous;
    public void OnPointerEnter(PointerEventData eventData)
    {
        mous = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mous = false;
    }

    #endregion


    public void OnEndDrag(PointerEventData eventData)
    {

        
        
            //возвращаем обратно в контент элемент
           transform.SetParent(DefaultParentTransform);
        transform.SetSiblingIndex(SiblingIndex);

      // var child = Instantiate(spawnElement)
       
            //hit.collider.gameObject.GetComponent<Renderer>().material = mainMaterial;
          //  GameObject spawnElementCopy = (GameObject)Instantiate(spawnElement);
          // spawnElement.transform.localPosition = new Vector3(0, 0, 0);
        
    }

}
