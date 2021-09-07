using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellWall : MonoBehaviour
{
    Vector3 s;
    bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (ready == false)
        {
            Debug.Log("¬ŒÀÿ≈¡Õ¿ﬂ —“≈Õ¿!");
            GameObject variableForPrefab = (GameObject)Resources.Load("SpellPrefabs/SpellWall", typeof(GameObject));
            GameObject spellwall = Instantiate(variableForPrefab, this.transform);
            spellwall.transform.SetParent(null);
          //  spellwall.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ready = true;
            Destroy(spellwall, 5f);
        }
    }
}
