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
    private AudioManager audioManager; // Add reference to AudioManager

    public int blueCollectiblesCaught = 0;
    public int totalBlueCollectibles = 10;
    public int playerHealth = 3;
    private int blueCollectiblesMissed = 0;
    private int totalCollectibles = 0;

    private bool gameActive = true;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<CollectibleSpawner>();
        audioManager = FindObjectOfType<AudioManager>(); // Initialize AudioManager
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
            EndGame(false); // Lose if health reaches 0
        }
        UpdateUI();
    }

    private void GameEndCondition()
    {
        if (totalCollectibles == totalBlueCollectibles)
        {
            if (blueCollectiblesCaught >= totalBlueCollectibles / 2)
            {
                EndGame(true); // Win if caught more than half
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
        playerMovement.DisableMovement();
        spawner.StopSpawning();

        // Stop collectibles
        foreach (var collectible in FindObjectsOfType<Rigidbody2D>())
        {
            collectible.velocity = Vector2.zero; // Stop movement
        }

        if (win)
        {
            winScreen.SetActive(true); // Show the win screen
            audioManager.PlayWinMusic(); // Play win music
        }
        else
        {
            loseScreen.SetActive(true); // Show the lose screen
            audioManager.PlayLoseMusic(); // Play lose music
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateUI()
    {
        pointsText.text = "Points: " + blueCollectiblesCaught;
        healthText.text = "Health: " + playerHealth;
    }
}
