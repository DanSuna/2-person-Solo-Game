using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        GetComponent<Button>().onClick.AddListener(gameManager.RestartGame);
    }
}
