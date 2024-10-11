using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;  // Set total health based on max
    }

    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;  // Update health bar with current health
    }
}
