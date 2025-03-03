// health.cs
using UnityEngine;
using UnityEngine.UI;

public class health : Pawn
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 50;
    public int healingAmount = 20;
    public HealthBarController healthBarController; // Reference to HealthBarController.

    void Start()
    {
        currentHealth = maxHealth;
        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth); // Update health bar at start.
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }

        // Update the health bar based on the current health percentage.
        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        // Update the health bar after taking damage.
        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth);
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Update the health bar after healing.
        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth);
    }

    private void Die()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoseGame();
        }

        gameObject.SetActive(false);
        Debug.Log("Player has died!");
    }
}
