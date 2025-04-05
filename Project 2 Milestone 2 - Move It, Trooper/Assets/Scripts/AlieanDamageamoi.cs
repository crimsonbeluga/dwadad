using UnityEngine;

public class AlieanDamageamoi : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public int damageAmount = 1;  // Amount of damage dealt
    public bool instantKill = false;  // If true, kills any object on collision

    // Reference to the audio source and sound clip
    public AudioClip collisionSound; // Sound to play on collision
    private AudioSource audioSource; // AudioSource to play the sound

    public AudioClip fireSound;
    [Range(0f, 50f)]  // Adding a range so the volume can be adjusted between 0 and 1
    public float soundVolume = 20.0f;  // Volume of the sound

    // Start method to initialize audio source
    void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Method called when another collider enters the trigger zone
    public void OnTriggerEnter2D(Collider2D other)
    {
        health healthComponent = other.GetComponent<health>();

        if (healthComponent != null)
        {
            // If instantKill is enabled, apply full damage to health (instant kill)
            if (instantKill)
            {
                healthComponent.TakeDamage(healthComponent.currentHealth); // Instant death
            }
            else
            {
                // Apply regular damage
                healthComponent.TakeDamage(damageAmount);
            }
        }
        else
        {
            // If no health component is found, log a message
            Debug.Log("Collided with an object without a Health component.");
        }

        // Play the fire sound with the adjustable volume
        AudioSource.PlayClipAtPoint(fireSound, transform.position, soundVolume);
    }
}
