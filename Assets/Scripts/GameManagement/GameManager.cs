using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Tire bulletManager;

    [SerializeField] private GameObject btnShoot;
    [SerializeField] private GameObject btnStart;
    [SerializeField] private TextMeshProUGUI PlayerShoot;
    [SerializeField] private TextMeshProUGUI turnDisplay;
    [SerializeField] private TextMeshProUGUI winMsg;

    private int turnCount = 1;
    private int actualIndex = 0;
    private GameObject actualPlayer;

    public void Awake()
    {
        btnShoot.SetActive(false);
        turnDisplay.gameObject.SetActive(false);
        winMsg.gameObject.SetActive(false);
    }

    public void LaunchGame()
    {
        if (playerManager.PlayersList.Count < 2) {
            return;
        }

        DisplayAllNames();
        UpdateTurnDisplay();
        btnStart.SetActive(false);
        turnDisplay.gameObject.SetActive(true);
        btnShoot.SetActive(true);
        actualPlayer = playerManager.PlayersList[actualIndex];
        actualPlayer.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        UpdatePlayerShootTxt();
    }

    private void DisplayAllNames()
    {
        foreach (var player in playerManager.PlayersList)
        {
            PlayerData playerData = player.GetComponent<PlayerData>();
            playerData.DisplayName();
        }
    }

    public void Shoot()
    {
        bool isShot = bulletManager.Roullette();
        if (isShot)
        {
            actualPlayer.GetComponentInChildren<Image>().enabled = false;
            actualPlayer.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            actualPlayer.GetComponent<PlayerData>().Isalive = false;

        }

        NextPlayer();
        UpdatePlayerShootTxt();

        CheckEndCondition();
    }

    public void NextPlayer()
    {
        actualPlayer.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;

        if (actualIndex+1 < playerManager.PlayersList.Count)
        {
            actualIndex++;
        } else
        {
            actualIndex = 0;
            turnCount++;
            UpdateTurnDisplay();
        }

        actualPlayer = playerManager.PlayersList[actualIndex];
        actualPlayer.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;

        if (actualPlayer.GetComponent<PlayerData>().Isalive == false)
        {
            NextPlayer();
        }
    }

    public void CheckEndCondition()
    {
        int count = 0;

        foreach (var player in playerManager.PlayersList)
        {
            if(player.GetComponent<PlayerData>().Isalive)
            {
                count++;
            }
        }

        if (count == 1)
        {
            btnShoot.SetActive(false);
            winMsg.text = $"{playerManager.PlayersList[actualIndex].GetComponent<PlayerData>().PlayerName} won ! They survived !";
            winMsg.gameObject.SetActive(true);
        }
    }

    public void UpdatePlayerShootTxt()
    {
        PlayerShoot.text = $"{actualPlayer.GetComponent<PlayerData>().PlayerName} Shoots";
    }

    public void UpdateTurnDisplay()
    {
        turnDisplay.text = $"Turn {turnCount}";
    }

}
