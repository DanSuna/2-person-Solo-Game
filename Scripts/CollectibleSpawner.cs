using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject blueCollectiblePrefab;
    public GameObject redCollectiblePrefab;
    public float spawnInterval = 2f;
    public float spawnRangeX = 8f;
    public float spawnHeight = 5f;

    private int blueCount = 0;
    public int totalBlues = 10;
    private bool gameActive = true;

    // Sets the probability of blue collectibles spawning (e.g., 70%)
    [Range(0, 100)] public int blueSpawnChance = 70;

    private void Start()
    {
        InvokeRepeating("SpawnCollectibles", spawnInterval, spawnInterval);
    }

    void SpawnCollectibles()
    {
        if (!gameActive) return;  // If the game is over, then the collectibles will stop spawning 

        // Generate a random number from 0 to 100
        int randomChoice = Random.Range(0, 100);

        // The blue collectibles will have a higher chance of spawning than the red collectibles
        if (randomChoice < blueSpawnChance && blueCount < totalBlues)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight);
            Instantiate(blueCollectiblePrefab, spawnPosition, Quaternion.identity);
            blueCount++;
        }
        else
        {
            Vector2 redSpawnPosition = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight);
            Instantiate(redCollectiblePrefab, redSpawnPosition, Quaternion.identity);
        }
    }

    public void StopSpawning()
    {
        gameActive = false;
        CancelInvoke("SpawnCollectibles");
    }
}
