using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject blueCollectiblePrefab1;
    public GameObject blueCollectiblePrefab2;
    public GameObject redCollectiblePrefab;
    public float spawnInterval = 2f;

    public Transform[] spawnPoints; // Array to hold spawn points

    private int blueCount = 0;
    public int totalBlues = 10;
    private bool gameActive = true;

    [Range(0, 100)] public int blueSpawnChance = 70;

    private void Start()
    {
        InvokeRepeating("SpawnCollectibles", spawnInterval, spawnInterval);
    }

    void SpawnCollectibles()
    {
        if (!gameActive) return;

        int randomChoice = Random.Range(0, 100);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length); // Get a random index
        Transform spawnPoint = spawnPoints[spawnPointIndex]; // Select the spawn point

        if (randomChoice < blueSpawnChance && blueCount < totalBlues)
        {
            GameObject chosenBluePrefab = Random.Range(0, 2) == 0 ? blueCollectiblePrefab1 : blueCollectiblePrefab2;
            Instantiate(chosenBluePrefab, spawnPoint.position, Quaternion.identity);
            blueCount++;
        }
        else
        {
            Instantiate(redCollectiblePrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void StopSpawning()
    {
        gameActive = false;
        CancelInvoke("SpawnCollectibles");
    }
}
