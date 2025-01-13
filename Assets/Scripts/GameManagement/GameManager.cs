using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.tvOS;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Tire bulletManager;
    private int turnCount;

    public void Start()
    {
        turnCount = 0;
    }

    public void Update()
    {
        
    }

    public void LaunchGame()
    {
        DisplayAllNames();

        while (playerManager.PlayersList.Count > 1)
        {
            turnCount++;
            StartTurn();
        }
        Debug.Log($"{playerManager.PlayersList[0].GetComponent<PlayerData>().PlayerName} a gagné il est vivant");
        
        
    }

    private void StartTurn()
    {
        Debug.Log($"Début du tour numéro {turnCount}");

        for (int i = playerManager.PlayersList.Count - 1; i >= 0; i--)
        {
            PlayerData playerData = playerManager.PlayersList[i].GetComponent<PlayerData>();

            if (bulletManager.Roullette())
            {
                Debug.Log($"{playerData.PlayerName} est mort");
                Destroy(playerManager.PlayersList[i]);
                playerManager.PlayersList.RemoveAt(i);
                if (playerManager.PlayersList.Count <= 1)
                {
                    return;
                }
            }
            else
            {
                Debug.Log($"{playerData.PlayerName} a survécu");
            }
        }


            Debug.Log($"Fin du tour");
    }

    private void DisplayAllNames()
    {
        foreach (var player in playerManager.PlayersList)
        {
            PlayerData playerData = player.GetComponent<PlayerData>();
            playerData.DisplayName();
        }
    }


}
