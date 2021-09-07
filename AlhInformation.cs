using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Mirror;

public class AlhInformation : NetworkBehaviour, IHasChanged
{
    public GameObject buttonchuk;
    private const string V = " - ";
    [SerializeField] Transform slots1;
    [SerializeField] Transform slots2;
    [SerializeField] Transform slots3;
    [SerializeField] Transform slots4;
    private Transform slots;
    [SerializeField] Text AlhText;
    public Text infotext;
    public string[] sendingWords;
    string info;
    public int kakoi;
    public int sendingkakoi;
    public int dmg;
    int fire = 0;
    int earth = 0;
    int water = 0;
    int air = 0;
    
    void Start()
    {
        slots = slots2;
        HasChanged();
        
    }

    public void ChoiceAlh1()
    {
        slots = slots1;
        kakoi = 1;
    }
    public void ChoiceAlh2()
    {
        slots = slots2;
        kakoi = 2;
    }
    public void ChoiceAlh3()
    {
        slots = slots3;
        kakoi = 3;
    }
    public void ChoiceAlh4()
    {
        slots = slots4;
        kakoi = 4;
    }


    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
       builder.Append(" ");
        foreach (Transform slotTransform in slots)
        {
            GameObject item = slotTransform.GetComponent<Slot>().item;
            if (item)
            {
                builder.Append(item.name);
               builder.Append(" - ");
            }
        }
       
        AlhText.text = builder.ToString();
        info = infotext.text;
        buttonchuk.GetComponent<Button>().onClick.Invoke();

    }

    public void SaveSpell()
    {
        

        char[] delimiterChars = { '-', '\t' };
        info.Replace(" ", "");
        string[] words = info.Split(delimiterChars);

        foreach (string element in words)
        {
              element.Replace(" ", string.Empty);
            Debug.Log(element);
        }
        sendingWords = words;
        sendingkakoi = kakoi;
       
    }
}

namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}