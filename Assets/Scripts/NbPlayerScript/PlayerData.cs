using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour
{
private string playerName;
private bool isalive = true;
[SerializeField] private TMP_InputField text;
[SerializeField] private TextMeshProUGUI NameDisplay;

public string PlayerName
{
    get => playerName;
    set => playerName = value;
}

public bool Isalive
{
    get => isalive;
    set => isalive = value;
}

public void UpdatePlayerName()
{
    playerName = text.text;
    NameDisplay.text = playerName;
}
}