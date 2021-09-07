using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : MonoBehaviour
{
   
    
    #region Singletone
    private static PlayerManager _instance;

    public static PlayerManager Instance
    {

        get
        {

            return _instance;

        }
    }

    #endregion

    [SerializeField]
    private string playerName;

    public string GetPlayerName
    {
        get
        {

            return playerName;

        }
    }

    private void Awake()
    {
        _instance = this;

    }

    [SerializeField]
    private NetworkManager netManager;

    public void SetPlayerName(string plName)
    {

        playerName = plName;

    }

    public void SpawnPlayer()
    {
        if (string.IsNullOrWhiteSpace(playerName)) //ѕроверка на им€, можно придумать менеджер проверок на сервере чтобы запретить неприличные имена
        {

            Debug.Log("»м€ не выбрано");
            return;
        }

        if (!netManager.clientLoadedScene)
            {

                if (!NetworkClient.ready) NetworkClient.Ready();

                NetworkClient.AddPlayer();
                UIManager.Instance.SpawnGroupToogle();
                UIManager.Instance.PlayerStatsGroupToogle();
                UIManager.Instance.SetUIPlayerName(playerName);
        }

        
    
    }
}
