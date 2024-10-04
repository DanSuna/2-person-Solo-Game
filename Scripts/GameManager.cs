using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text pointsText;
    public Text healthText;
    public GameObject winScreen;
    public GameObject loseScreen;

    private PlayerMovement playerMovement;
    private CollectibleSpawner spawner;

    public int blueCollectiblesCaught = 0;    // Number of blue collectibles caught
    public int totalBlueCollectibles = 10;    // Total number of blue collectibles (This can be changed)
    public int playerHealth = 3;              // Player health
    private int blueCollectiblesMissed = 0;   // Number of blue collectibles missed
    private int totalCollectibles = 0; // Total of caught + missed collectibles

    private bool gameActive = true;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<CollectibleSpawner>();
        UpdateUI();
    }

    public void CatchBlueCollectible()
    {
        if (!gameActive) return;

        blueCollectiblesCaught++;
        totalCollectibles++;
        GameEndCondition();
        UpdateUI();
    }

    public void MissBlueCollectible()
    {
        if (!gameActive) return;

        blueCollectiblesMissed++;
        totalCollectibles++;
        GameEndCondition();
    }

    public void TakeDamage()
    {
        if (!gameActive) return;

        playerHealth--;
        if (playerHealth <= 0)
        {
            EndGame(false);  // Lose if health reaches 0
        }
        UpdateUI();
    }

    private void GameEndCondition()
    {
        if (totalCollectibles == totalBlueCollectibles)
        {
            if (blueCollectiblesCaught >= totalBlueCollectibles / 2)
            {
                EndGame(true);  // Win if caught more than half
            }
            else
            {
                EndGame(false); // Lose if caught less than half
            }
        }
    }

    private void EndGame(bool win)
    {
        gameActive = false;
        playerMovement.DisableMovement(); // Disable player movement
        spawner.StopSpawning();          // Stop spawning collectibles

        if (win)
        {
            winScreen.SetActive(true);   // Show the win screen
        }
        else
        {
            loseScreen.SetActive(true);  // Show the lose screen
        }
    }

    private void UpdateUI()
    {
        pointsText.text = "Points: " + blueCollectiblesCaught;
        healthText.text = "Health: " + playerHealth;
    }
}
