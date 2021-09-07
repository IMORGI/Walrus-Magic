using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDummy : MonoBehaviour
{
    public Image hpBar;
    public float maxHp = 100;
    public float curHp;

    void Update()
    {
        hpBar.fillAmount = curHp / maxHp;
        if(curHp < maxHp)
        {
            curHp += 0.02f;
        }
    }

    void Start()
    {
        curHp = maxHp;
    }

    private void LateUpdate()
    {
       // transform.position = Camera.main.WorldToScreenPoint(hpBar.transform.position + Vector3.up);
    }

}
