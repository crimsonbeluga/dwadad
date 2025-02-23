using UnityEngine;

public class health : Pawn
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 100;  // Amount of damage taken
    public int healingAmount = 20;

    void Start()
    {
        currentHealth = maxHealth;  // Initialize health at the start 
    }

    void Update()
    {
        // Check for death condition every frame
        if (currentHealth <= 0)
        {
            // Call the Die method to handle death
            Die();
        }
    }

    // Take damage and handle death
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Heal the player up to the maximum health
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    // Handle player death
    private void Die()
    {
        // Call the GameManager's LoseGame() method to end the game
        if (GameManager.instance != null)
        {
            GameManager.instance.LoseGame();
        }

        // Optionally, disable or destroy the player object after death
        gameObject.SetActive(false);  // Disable the object (can be replaced with other actions like playing a death animation)
        Debug.Log("Player has died!");
    }
}
