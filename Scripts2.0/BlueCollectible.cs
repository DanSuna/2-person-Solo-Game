using UnityEngine;

public class BlueCollectible : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource audioSource;
    public AudioClip blueCollectSound;
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
            audioManager.PlaySFX(audioManager.collect);  // Play sound when collected
            gameManager.CatchBlueCollectible();  // Update the game manager with caught blue collectible
            Destroy(gameObject);  // Destroy blue collectible
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            gameManager.MissBlueCollectible();  // Update the game manager with missed blue collectible
            Destroy(gameObject);  // Destroy blue collectible
        }
    }
}
