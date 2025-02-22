using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public int damageAmount = 1; // Amount of damage dealt
    public bool instantKill = false; // If true, kills any object on collision

    // Called when another collider enters this object's trigger collider
 public void OnTriggerEnter2D(Collider2D other)

    {
        // Check if the other object has a Health component
        health healthComponent = other.GetComponent<health>();

        if (healthComponent != null)
        {
            if (instantKill)
            {
                // Instantly kill the object
                healthComponent.TakeDamage(healthComponent.currentHealth); // Assuming TakeDamage handles death
            }
            else
            {
                // Apply damage
                healthComponent.TakeDamage(damageAmount);
            }
        }
        else
        {
            // Handle case where the object doesn't have a Health component
            Debug.Log("Collided with an object without a Health component.");
        }
    }
}
