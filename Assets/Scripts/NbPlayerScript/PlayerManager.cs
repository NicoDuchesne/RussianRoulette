using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
 private int nbPlayer = 0;
 private int maxNbPlayer = 10;
 [SerializeField] private TextMeshProUGUI text;
 private string baseText = "Nb Player: ";
 [SerializeField] private List<GameObject> playersList = new List<GameObject>();
 [SerializeField] private GameObject playerPrefab;
 [SerializeField] private GameObject playerContainer;

 public void AddPlayer()
 {
    if (nbPlayer >= maxNbPlayer)
    {
        return;
    }
  nbPlayer++;
  GameObject player = Instantiate(playerPrefab, playerContainer.transform);
  playersList.Add(player);
  UpdateTxt();
 }

 public void RemovePlayer()
 {
    if (nbPlayer <= 0)
    {
        return;
    }
  nbPlayer--;
  Destroy(playersList[nbPlayer]);
  playersList.RemoveAt(nbPlayer);
  UpdateTxt();
 }

 private void UpdateTxt()
 {
    text.text = baseText + nbPlayer;
 }
}
