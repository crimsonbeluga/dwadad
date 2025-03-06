using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Required for coroutines

public class health : Pawn
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 50;
    public int healingAmount = 20;
    public HealthBarController healthBarController; // Reference to HealthBarController.

    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer
    private Coroutine pulseCoroutine; // Stores reference to pulse coroutine

    void Start()
    {
        currentHealth = maxHealth;
        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth); // Update health bar at start.
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
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

        // Start the pulse effect
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
        }
        pulseCoroutine = StartCoroutine(PulseEffect());
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

    // Coroutine to pulse transparency
    private IEnumerator PulseEffect()
    {
        float pulseDuration = 2f; // How long the pulse effect lasts
        float pulseSpeed = 15f; // How fast it pulses
        float elapsedTime = 0f;

        while (elapsedTime < pulseDuration)
        {
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * pulseSpeed)); // Creates a fast fade in/out effect
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(1f, 1f, 1f, alpha); // Change transparency
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the object is fully visible after pulsing
        if (spriteRenderer != null)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
