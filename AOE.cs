using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    Vector3 a;
    public int dmg = 10;
    private void Start()
    {
        var a =this.transform;
    }

    // Update is called once per frame
    void Update()
    {
       var hitColliders = Physics.OverlapSphere(a, 5);
        foreach(var iter in hitColliders)
        {
         var iterHpDummy =  iter.GetComponent<HPDummy>();
            if (iterHpDummy !=null)
            {
                iterHpDummy.curHp -= dmg;
            }
        }
    }
}
