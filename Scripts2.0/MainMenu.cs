using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>(); // Find the AudioManager
    }

    public void StartGame()
    {
        audioManager.StopCurrentMusic(); // Stop menu music
        SceneManager.LoadScene("GameSceneName"); // Change to your game scene name
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}
