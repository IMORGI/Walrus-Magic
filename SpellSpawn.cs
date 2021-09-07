using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;
public class SpellSpawn : NetworkBehaviour
{
    public GameObject pricel;
    public GameObject sukaManager;
    #region Префабы элементов 
    public GameObject alh1_prefab;
    public GameObject alh2_prefab;
    public GameObject alh3_prefab;
    public GameObject alh4_prefab;
    private GameObject spell;
    public GameObject fire_prefab;
    public GameObject water_prefab;
    public GameObject air_prefab;
    public GameObject earth_prefab;
    public GameObject cryo_prefab;
    public GameObject electro_prefab;
    public GameObject dark_prefab;
    public GameObject holy_prefab;
    private GameObject element;
    public GameObject fire_Trow_prefab;
    public GameObject water_Trow_prefab;
    public GameObject air_Trow_prefab;
    public GameObject earth_Trow_prefab;
    public GameObject cryo_Trow_prefab;
    public GameObject electro_Trow_prefab;
    public GameObject dark_Trow_prefab;
    public GameObject holy_Trow_prefab;
    #endregion
    public GameObject spellBullet_prefub;
    private GameObject spellBullet;
    public GameObject bullet_prefub;
    public GameObject prototipe_prefub;
    public string script;
    public string scriptEffect;
    public int kakoi;
    private int slot = 0;
    private int f = 3;
    private int e = 3;
    private int olo = -1;
    int smork;
    public float Power;
    public float speed = 0.1f;
    string suka;
    public string[] words;
    public int dmgSpell;
    bool spellready= true;
  
    

    void Start()
    {
       
            if (isLocalPlayer)
            {
                Camera.main.GetComponentInParent<WizardCameraHandler>().Character = this.transform;
            }
      
        sukaManager = GameObject.Find("SukaManager");
        kakoi = sukaManager.GetComponent<SukaManager>().sendkakoi;
        Debug.Log("какой:" + kakoi);
        words = sukaManager.GetComponent<SukaManager>().sendWords;
       
      
        if (this.isLocalPlayer)
        {

           // CmdAlh();
                   
                  
        }
    }

    void Update()
    {
        if (this.isLocalPlayer && Input.GetKeyDown(KeyCode.Q) && spellready /*&& hasAuthority*/)
        {
            
         
                CmdAlh();
           
            /* Fire();
             SpellSpawnBullet();*/
        }
    }

    void Fire()
    {
      GameObject  snaryad = Instantiate(bullet_prefub, pricel.transform);
        snaryad.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1, 0, 0) * speed);
    }


    #region Выбор Алхимического круга
   [Command]
    public void CmdAlh()
    {
        if (hasAuthority)
        {
            spellready = false;
            if (kakoi == 1)
            {
                spell = Instantiate(alh1_prefab, this.transform);
                script = "FIreBall";
            }
            if (kakoi == 2)
            {
                script = "FIreBall";
                spell = Instantiate(alh2_prefab, this.transform);
            }
            if (kakoi == 3)
            {
                spell = Instantiate(alh3_prefab, this.transform);
                script = "AOE";
            }
            if (kakoi == 4)
            {
                spell = Instantiate(alh4_prefab, this.transform);
                script = "FIreBall";//добавить в if(words0=fire и тд) чтобы если fireball или если AOE были разные добавочные эффекты
            }
            NetworkServer.Spawn(spell);
            if (isServer)
            {
                RpcSpawnAll();
            }
            CmdSpellMassivSpawn();
        }
    }

   

    [Command]
    void CmdSpellMassivSpawn()
    {
       
        
            words = sukaManager.GetComponent<SukaManager>().sendWords;
            //  Debug.Log("��� ��������:" + words[0] + words[1] + words[2] + words[3] + words[4] + words[5] + words[6] + words[7] + words[8]);
            smork = words.Length;

        CmdSpawnElement();
    }

    [Command]
    void CmdSpawnElement()
    {
        StartCoroutine(SpawnElement());
    }
    #region Создание элементов внутри 

    IEnumerator SpawnElement()
    {

        {
            if (hasAuthority)
            {
                for (int i = 0; i < smork; i++)
                {


                    if (words[i] == " Fire ")
                    {

                        element = Instantiate(fire_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Earth ")
                    {
                        element = Instantiate(earth_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Water ")
                    {
                        element = Instantiate(water_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Air ")
                    {
                        element = Instantiate(air_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Cryo ")
                    {
                        element = Instantiate(cryo_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Electro ")
                    {
                        element = Instantiate(electro_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Holy ")
                    {
                        element = Instantiate(holy_prefab, spell.transform.GetChild(i));

                    }
                    else if (words[i] == " Dark ")
                    {
                        element = Instantiate(dark_prefab, spell.transform.GetChild(i));

                    }
                    NetworkServer.Spawn(element);
                    yield return new WaitForSeconds(1.2f);
                   // Debug.Log("������ �������");

                }
            }

            #region Эффект первой тройки
            if (words.Length > 0)
            {
                if (words[0] == words[1] && words[0] == words[2])
                {
                    if (words[0] == " Fire ")
                    {
                        bullet_prefub = fire_Trow_prefab;
                        dmgSpell = 10;
                    }
                    if (words[0] == " Water ")
                    {
                        bullet_prefub = water_Trow_prefab;
                        dmgSpell = 5;
                    }
                    if (words[0] == " Earth ")
                    {
                        bullet_prefub = earth_Trow_prefab;
                        dmgSpell = 2;
                    }
                    if (words[0] == " Air ")
                    {
                        bullet_prefub = air_Trow_prefab;
                        dmgSpell = 1;
                    }
                    if (words[0] == " Cryo ")
                    {
                        bullet_prefub = cryo_Trow_prefab;

                    }
                    if (words[0] == " Electro ")
                    {
                        bullet_prefub = electro_Trow_prefab;

                    }
                    if (words[0] == " Holy ")
                    {
                        bullet_prefub = holy_Trow_prefab;

                    }
                    if (words[0] == " Dark ")
                    {
                        bullet_prefub = dark_Trow_prefab;

                    }


                }
                else bullet_prefub = spellBullet_prefub;

              
            }
            #endregion
            #region Эффект Второй тройки
            if (words.Length > 4)
            {
                if (words[3] == words[4] && words[3] == words[5])
                {
                    if (words[3] == " Fire ")
                    {
                        scriptEffect = "Shrapnel";
                    }
                    if (words[3] == " Water ")
                    {

                    }
                    if (words[3] == " Earth ")
                    {
                        scriptEffect = "SpellWall"; 
                    }
                    if (words[3] == " Air ")
                    {

                    }
                    if (words[3] == " Cryo ")
                    {


                    }
                    if (words[3] == " Electro ")
                    {


                    }
                    if (words[3] == " Holy ")
                    {
                        scriptEffect = "SummonSmallSpirit"; 

                    }
                    if (words[3] == " Dark ")
                    {


                    }


                }
               // else bullet_prefub = spellBullet_prefub;

                
            }
            #endregion
            Invoke("CmdSpellDisable", 5f);
            Invoke("CmdSpellSpawnBullet", 6f);
            Invoke("CmdSpellSpawnBullet", 7.5f);
            Invoke("CmdSpellSpawnBullet", 9f);
        }


    }
    #endregion
    #endregion



    [ClientRpc]
    void RpcSpawnAll()
    {
        
            NetworkServer.Spawn(spell);
                   
    }

    [Command]
    void CmdSpellSpawnBullet()
    {
        if (hasAuthority)
        {
            spellBullet = Instantiate(bullet_prefub, this.transform);
            
            var type = Type.GetType(script);
            spellBullet.AddComponent(type);
            var type1 = Type.GetType(scriptEffect);
            spellBullet.AddComponent(type1);
            var DMGSPELL = spellBullet.GetComponent<SpellStats>();
            DMGSPELL.dmg = dmgSpell;
            Debug.Log(DMGSPELL.dmg);
            NetworkServer.Spawn(spellBullet);
        }
    }
    [Command]
    void CmdSpellDisable()
    {
        if (hasAuthority)
        {
            // spell.SetActive(false);
            Destroy(spell);
            spellready = true;
        }
    }

   
    
   
}

