using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    private int turnCount;

    void Start()
    {
        turnCount = 0;
    }

    void Update()
    {
        while(players.Length > 0)
        {
            turnCount++;
            StartTurn();
        }
    }

    void StartTurn()
    {
        Debug.Log($"Debut du tour {turnCount}");
        int count = 0;
        foreach (GameObject player in players)
        {
            if(player.TryGetComponent<Tire>(out Tire shoot))
            {
                count++;
                if (shoot.Roullette()) {
                    Destroy(player);
                    Debug.Log($"le joueur {count} est mort");
                } else
                {
                    Debug.Log($"le joueur {count} a survécu");
                }
            }
        }
        Debug.Log("Fin du tour");
        Debug.Log($"{players.Length} joueurs ont survécu");
    }

}
