using UnityEngine;

public class BlueCollectible : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // When the blue collectible collides with the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.CatchBlueCollectible();  // Update the game manager with caught blue collectible
            Destroy(gameObject);                 // Destroy blue collectible
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            gameManager.MissBlueCollectible();   // Update the game manager with missed blue collectible
            Destroy(gameObject);                 // Destroy blue collectible
        }
    }
}
