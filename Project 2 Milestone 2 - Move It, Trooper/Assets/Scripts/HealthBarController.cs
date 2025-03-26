// HealthBarController.cs
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : health
{
    public Image healthBar;  // Reference to the UI Image component representing the health bar.

    // Method to update the health bar.
    public void UpdateHealthBar(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
    }
}