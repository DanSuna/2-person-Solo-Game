using UnityEngine;

public class RedCollectible : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;
    [SerializeField] private float damage;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioManager.PlaySFX(audioManager.damage);  // Play sound when collected
            gameManager.TakeDamage();  // Damage the player
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);  // Apply damage to player health
            Destroy(gameObject);  // Destroy red collectible
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);  // Destroy red collectible when hitting the ground
        }
    }
}
