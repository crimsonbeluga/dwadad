using UnityEngine;
using UnityEngine.UI; // Ensure this is included for UI Text
using UnityEngine.SceneManagement;
using System.Collections;

public class health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageAmount = 50;
    public int healingAmount = 20;
    public HealthBarController healthBarController; // Reference to HealthBarController.

    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer
    private Coroutine pulseCoroutine; // Stores reference to pulse coroutine

    private Text scoreText;  // Reference to the UI Text for the score (named CountText)
    private int score = 0;  // Store the score

    // Add this to keep track of the position of the health bar in screen space
    public Camera MainCamera; // Reference to the main camera

    void Start()
    {
        // Initialize current health
        currentHealth = maxHealth;
        Debug.Log("Object initialized with health: " + currentHealth);  // Debugging to track the initial health value

        // Find the GameManager instance and update the score text
        GameManager.instance.AddScore(0);  // Initialize the score if necessary

        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth); // Update health bar at start.
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
        MainCamera = Camera.main; // Set the main camera for world-to-screen conversion
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
          
        }

        // Update the health bar based on the current health percentage.
        healthBarController.UpdateHealthBar((float)currentHealth / maxHealth);

        // Keep the health bar above the player in screen space
        
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
        // If the object is tagged as Player, load the GameOver scene.
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has died! Loading GameOver scene...");
            StartCoroutine(LoadGameOverScene());
        }
        else
        {
            // Otherwise, increment the score and destroy the object.
            Debug.Log(gameObject.name + " has been destroyed.");
            IncrementScore();  // Increase score by 1 when object is destroyed
            Destroy(gameObject);
        }
    }

    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f); // Small delay before loading
        SceneManager.LoadScene("GameOver");
    }

    // Increment the score and update the UI text
    private void IncrementScore()
    {
        GameManager.instance.AddScore(1);  // Increase score by 1 in the GameManager
        Debug.Log("Score updated in GameManager. Current Score: " + GameManager.instance.GetScore());
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
