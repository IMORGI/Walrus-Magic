using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewElement : MonoBehaviour
{
    public GameObject thePrefab;
    public Transform theParent;

  

    public void AddElement()
    {
        // Debug.Log("Ячейка занята");
        if (gameObject.transform.childCount == 0)
        {
            // Debug.Log("создаем новый элемент");

            var child = Instantiate(thePrefab, theParent);
            child.name = thePrefab.name;
        }
        else
        {
           GameObject child = this.gameObject.transform.GetChild(0).gameObject;
            child.transform.localPosition = Vector3.zero;
        }

    }
}
