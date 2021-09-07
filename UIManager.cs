using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    #region Singletone
    private static UIManager _instance;

    public static UIManager Instance
    {

        get
        {

            return _instance;

        }
    }

    #endregion


    private void Awake()
    {
        _instance = this;

    }
    #region UI Группы
    [SerializeField]
    private GameObject spawnGroupContainer;

    [SerializeField]
    private GameObject playerStatsGroupContainer;
    #endregion

    [SerializeField]
    private Text nameField;


    public void SetUIPlayerName(string pl)
    {

        nameField.text = pl;

    }


    public void SpawnGroupToogle()
    {

        spawnGroupContainer.SetActive(!spawnGroupContainer.activeSelf);



    }

    public void PlayerStatsGroupToogle()
    {

        playerStatsGroupContainer.SetActive(!playerStatsGroupContainer.activeSelf);



    }
}
