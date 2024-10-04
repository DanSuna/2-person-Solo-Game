using UnityEngine;

public class RedCollectible : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // When the red collectible collides with the player or ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.TakeDamage();   // Damage the player
            Destroy(gameObject);                 // Destroy red collectible
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);                 // Destroy red collectible when hitting the ground
        }
    }
}
