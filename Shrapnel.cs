using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ÿ–¿œÕ≈À‹!");
        GameObject variableForPrefab = (GameObject)Resources.Load("SpellPrefabs/BigFireBall", typeof(GameObject));
        GameObject spellwall = Instantiate(variableForPrefab, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
