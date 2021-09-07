using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class SukaManager : NetworkBehaviour
{
   public GameObject magicEditor;
  public string[] sendWords;
    public int sendkakoi;
    public int dmg;
  


    public void SendSpell()
    {
        sendWords = magicEditor.GetComponent<AlhInformation>().sendingWords;
        sendkakoi = magicEditor.GetComponent<AlhInformation>().sendingkakoi;
        dmg = magicEditor.GetComponent<AlhInformation>().dmg;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadEffectScene()
    {
        SceneManager.LoadScene("EffectScene");
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
