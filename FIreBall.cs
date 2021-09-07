using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreBall : MonoBehaviour
{
    
    public int dmg;
    private void Start()
    {
        
        this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500, ForceMode.Impulse);
    var  spellStats =  this.gameObject.GetComponent<SpellStats>();
      dmg =  spellStats.dmg;
        this.transform.SetParent(null);
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        var hitColliders = Physics.OverlapSphere(this.transform.position, 5);
        foreach (var iter in hitColliders)
        {
            var iterHpDummy = iter.GetComponent<HPDummy>();
            if (iterHpDummy != null)
            {
                iterHpDummy.curHp -= dmg;
                Debug.Log(iterHpDummy.curHp);
            }
        }
        Destroy(this.gameObject,1f);
    }
    
}
