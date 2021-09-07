using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
 
public class PlayerSpawnSpell : NetworkBehaviour
{
   public GameObject smork;
    public GameObject bullet;
    [SerializeField]
    public GameObject spellPrefab;

    [SerializeField]
    public float spellSpeed;

    Vector3 pos ;

    void Update()
    {
        if (this.isLocalPlayer && Input.GetKeyDown(KeyCode.E))
        {
             this.CmdShoot();
            
        }
    }

    [Command]
    void CmdShoot()
    {
        GameObject bullet = Instantiate(spellPrefab, this.transform.position, this.transform.rotation);
        bullet.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        bullet.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        bullet.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
        bullet.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
        bullet.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        bullet.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);

        //  bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * spellSpeed;
       
        RpcOnShoot();

     // Destroy(bullet, 5.0f);
    }

    [ClientRpc]
    void RpcOnShoot()
    {
        NetworkServer.Spawn(bullet);
        /*   bullet.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
           bullet.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
           bullet.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
           bullet.transform.GetChild(3).GetChild(0).gameObject.SetActive(true);
           bullet.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
           bullet.transform.GetChild(3).GetChild(3).gameObject.SetActive(true);*/
    }

   /* void SpellSmork()
    {
        GameObject childsmork =  smork.GetComponentInChildren();
        childsmork.SetActive(true);
    }*/
}

