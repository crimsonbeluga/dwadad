using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathTarget : DeathDestroy
{
    public int pointValue = 1; // Point value for destroying the target (set to 1)

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the "Pickup" tag
        if (other.gameObject.CompareTag("Pickup"))
        {
            Debug.Log("Pickup detected! Adding points.");
            // Update the score in the GameManager
            GameManager.instance.AddScore(pointValue);  // Add score
        }
    }
}
